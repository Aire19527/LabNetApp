using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
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
            int count = question.QuestionAnswerEntities.Where( x => x.IsCorrect == true ).Count();
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