using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Assessment;
using Lab.Domain.Dto.AssessmentQuestion;
using Lab.Domain.Dto.AssessmentQuestionAnswer;
using Lab.Domain.Dto.AssessmentUser;
using Lab.Domain.Services.Interfaces;

namespace Lab.Domain.Services
{
    public class AssessmentUserService : IAssessmentUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionServices _questionServices;

        public AssessmentUserService(IUnitOfWork unitOfWork, IQuestionServices questionServices)
        {
            _unitOfWork = unitOfWork;
            _questionServices = questionServices;
        }

        public List<ConsultAssessmentUserDto> GetAssessment()
        {

            IEnumerable<AssessmentUserEntity> assessmentUserList =
                _unitOfWork.AssessmentUserRepository.GetAllSelect(
                        q => q.AssessmentQuestionEntities.Select(x => x.QuestionEntity.FileEntity),
                        x => x.AssessmentQuestionEntities
                              .Select(x => x.AssessmentQuestionAnswerEntities
                              .Select(a => a.AnswerEntity.FileEntity)),
                        x => x.RequestEntity);

            List<ConsultAssessmentUserDto> assessmentUser =
                assessmentUserList.Select(x => new ConsultAssessmentUserDto()
                {
                    IdRequest = x.IdRequest,
                    DateAssessment = x.RequestEntity.CreationDate,
                    RequestTitle = x.RequestEntity.Title,
                    PointsObtained = x.PointsObtained,
                    ConsultAssessmentQuestion = x.AssessmentQuestionEntities
                        .Select(aq => new ConsultAssessmentQuestionDto()
                        {
                            
                            IdQuestion = aq.IdQuestion,
                            QuestionDescription = aq.QuestionEntity.Description,
                            UrlQuestion = aq.QuestionEntity.FileEntity?.Url,
                            AssessmentAnswer = aq.AssessmentQuestionAnswerEntities
                                .Select(aa => new AssessmentAnswerDto()
                                {
                                    IdAnswer = aa.IdAnswer,
                                    AnswerDescription = aa.AnswerEntity?.Description,
                                    UrlAnswer = aa.AnswerEntity?.FileEntity?.Url,
                                    //IsCorrect = aa.is
                                }).ToList()
                        }).ToList()
                }).ToList();

            return assessmentUser;
        }

        public async Task<bool> Insert(AddAssessmentUserDto addAssessmentUserDto, int idUser)
        {
            List<AssessmentQuestionEntity> assessmentQuestions =
                new List<AssessmentQuestionEntity>();

            AssessmentUserEntity assessmentUserEntity = new AssessmentUserEntity()
            {
                IdRequest = addAssessmentUserDto.IdRequest,
                IdUser = idUser,
            };

            foreach (var item in addAssessmentUserDto.AssessmentQuestion)
            {
                AssessmentQuestionEntity assessmentQuestion = new AssessmentQuestionEntity()
                {
                    IdQuestion = item.IdQuestion,
                };

                QuestionEntity question = _questionServices.GetQuestionEntity(item.IdQuestion);

                assessmentQuestion.AssessmentQuestionAnswerEntities = item.AssessmentQuestionAnswer
                    .Select(y => new AssessmentQuestionAnswerEntity()
                    {
                        IdAnswer = y.IdAnswer,
                        Points = ConsultAnswer(y, question)
                    }).ToList();

                assessmentQuestions.Add(assessmentQuestion);
            }

            assessmentUserEntity.AssessmentQuestionEntities = assessmentQuestions;

            _unitOfWork.AssessmentUserRepository.Insert(assessmentUserEntity);

            return await _unitOfWork.Save() > 0;
        }

        private decimal ConsultAnswer(AssessmentQuestionAnswerDto questionAnswer, QuestionEntity question)
        {
            int count = question.QuestionAnswerEntities.Where(x => x.IsCorrect == true).Count();
            int point = question.DifficultyEntity.Value;


            var answer = question.QuestionAnswerEntities.FirstOrDefault(x => x.AnswerId == questionAnswer.IdAnswer
                                                          && x.IsCorrect == questionAnswer.IsCorrect);

            decimal value = 0;

            if (answer != null && answer.IsCorrect)
            {
                value = (point / count);
            }

            return value;
        }
    }
}