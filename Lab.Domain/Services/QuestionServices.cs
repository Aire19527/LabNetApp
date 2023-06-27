using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.File;
using Lab.Domain.Dto.Question;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class QuestionServices : IQuestionServices
    {
        #region builder
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IAnswerService _answerService;

        #endregion

        public QuestionServices(IUnitOfWork unitOfWork, IFileService fileService, IAnswerService answerService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _answerService = answerService;

        }

        public List<QuestionDto> getAll()
        {
            IEnumerable<QuestionEntity> entities = _unitOfWork.QuestionRepository.GetAllSelect(
                s => s.QuestionSkillEntity.Select(q => q.SkillEntity),
                i => i.FileEntity,
                a => a.QuestionAnswerEntities.Select(r => r.AnswerEntity));

            List<QuestionDto> questionList = entities.Select(q => new QuestionDto()
            {
                Id = q.Id,
                Description = q.Description,
                //IdSkill = q.Skill?.Id,
                //SkillDescription = q.Skill.Description,
                IdFile = q.FileEntity?.Id,
                IsVisible = q.IsVisible,
                Value = q.Value,
                SkillEntities = q.QuestionSkillEntity.Select(x => new ConsultSkllDto()
                {
                    Id = x.SkillEntity.Id,
                    Description = x.SkillEntity.Description,
                    IsVisible = x.SkillEntity.IsVisible
                }).ToList(),
                AnswerEntities = q.QuestionAnswerEntities
                    .Select(x => new GetAnswerDto()
                    {
                        Id = x.AnswerEntity.Id,
                        Description = x.AnswerEntity.Description,
                        IdFile = x.AnswerEntity.IdFile,
                        isCorrect = x.isCorrect
                    }).ToList(),
            }).ToList();

            return questionList;
        }

        public QuestionDto getById(int idQuestion)
        {
            QuestionEntity entity = _unitOfWork.QuestionRepository.FirstOrDefaultSelect(
                x => x.Id == idQuestion,
                s => s.QuestionSkillEntity.Select(q => q.SkillEntity),
                i => i.FileEntity,
                a => a.QuestionAnswerEntities.Select(r => r.AnswerEntity));

            if (entity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            QuestionDto question = new QuestionDto()
            {
                Id = entity.Id,
                Description = entity.Description,
                //IdSkill = entity.Skill?.Id,
                IdFile = entity.FileEntity?.Id,
                IsVisible = entity.IsVisible,
                Value = entity.Value,
                SkillEntities = entity.QuestionSkillEntity.Select(x => new ConsultSkllDto()
                {
                    Id = x.SkillEntity.Id,
                    Description = x.SkillEntity.Description,
                    IsVisible = x.SkillEntity.IsVisible
                }).ToList(),
                AnswerEntities = entity.QuestionAnswerEntities
                    .Select(x => new GetAnswerDto()
                    {
                        Id = x.AnswerEntity.Id,
                        Description = x.AnswerEntity.Description,
                        IdFile = x.AnswerEntity.IdFile,
                        isCorrect = x.isCorrect

                    }).ToList()
            };

            return question;
        }


        public async Task<bool> Delete(int id)
        {
            QuestionEntity? entity = _unitOfWork.QuestionRepository.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.QuestionRepository.Delete(entity);

            if (entity.IdFile != null)
               await _fileService.Delete((int)entity.IdFile);


            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> Insert(QuestionFileDto questionDto)
        {
            AddFileDto file = new AddFileDto()
            {
                File = questionDto.File,
            };

            FileEntity img = null;
            List<QuestionAnswerEntity> questionAnswers = new List<QuestionAnswerEntity>();
            
            using (var db = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    if (questionDto.File != null)
                        img = _fileService.InsertFile(file);

                    if (questionDto.AnswersInsert.Any())
                    {
                        foreach (var item in questionDto.AnswersInsert)
                        {
                            AnswerEntity answer = await _answerService.InsertToQuestion(item);
                            questionAnswers.Add(new QuestionAnswerEntity()
                            {
                                isCorrect = item.IsCorrect,
                                AnswerEntity = answer,
                            });
                        }
                    }

                    if (questionDto.Answers.Any())
                    {
                        List<QuestionAnswerEntity> list = questionDto.Answers.Select(a => new QuestionAnswerEntity()
                        {
                            isCorrect = a.IsCorrect,
                            AnswerId = a.IdAnswer
                        }).ToList();
                        questionAnswers.AddRange(list);
                    }

                    if (!questionAnswers.Any())
                        throw new BusinessException(GeneralMessages.RequiredAnswer);

                    if (!questionDto.Skills.Any())
                        throw new BusinessException(GeneralMessages.RequiredSkill);


                    QuestionEntity entity = new QuestionEntity()
                    {
                        IsVisible = true,
                        Value = questionDto.Value,
                        Description = questionDto.Description,
                        FileEntity = img,
                        QuestionAnswerEntities = questionAnswers,
                        QuestionSkillEntity = questionDto.Skills.Select(s => new QuestionSkillEntity()
                        {
                            IdSkill = s
                        }).ToList(),
                    };

                    _unitOfWork.QuestionRepository.Insert(entity);

                    await _unitOfWork.Save();
                    await db.CommitAsync();

                    return true;
                }
                catch (BusinessException ex)
                {
                    if (img != null)
                        _fileService.DeleteFile(img.Url);
                    
                    await db.RollbackAsync();

                    throw ex;
                }
                catch (Exception ex)
                {
                    if (img != null)
                        _fileService.DeleteFile(img.Url);
                    
                    await db.RollbackAsync();

                    throw new Exception(GeneralMessages.Error500, ex);
                }
            }
        }
    }
}
