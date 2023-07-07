using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.AssessmentQuestion;
using Lab.Domain.Dto.AssessmentQuestionAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class AssessmentQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AssessmentQuestionEntity Get(AssessmentQuestionDto assessmentQuestionDto)
        {

            List<AssessmentQuestionAnswerEntity> assessmentQuestionAnswerList =
                new List<AssessmentQuestionAnswerEntity>();

            foreach (var item in assessmentQuestionDto.AssessmentQuestionAnswer)
            {
                AssessmentQuestionAnswerEntity assessmentQuestionAnswerEntity = 
                    new AssessmentQuestionAnswerEntity()
                    {
                        IdAnswer = item.IdAnswer,
                    };

                assessmentQuestionAnswerList.Add(assessmentQuestionAnswerEntity);
            }

            AssessmentQuestionEntity assessmentQuestionEntity =
                new AssessmentQuestionEntity()
                {
                    IdQuestion = assessmentQuestionDto.IdQuestion,
                    AssessmentQuestionAnswerEntities = assessmentQuestionAnswerList
                };

            return assessmentQuestionEntity;
        }
    }
}
