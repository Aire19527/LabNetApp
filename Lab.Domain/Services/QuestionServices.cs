using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.File;
using Lab.Domain.Dto.Question;
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
        #endregion

        public  QuestionServices(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public List<QuestionDto> getAll()
        {
            IEnumerable<QuestionEntity> entities = _unitOfWork.QuestionRepository.GetAllSelect(
                s => s.Skill,
                i => i.FileEntity,
                a => a.QuestionAnswerEntities.Select(r => r.AnswerEntity));

            List<QuestionDto> questionList = entities.Select(q => new QuestionDto()
            {
                Id = q.Id,
                Description = q.Description,
                IdSkill = q.Skill?.Id,
                IdFile = q.FileEntity?.Id,
                IsVisible = q.IsVisible,
                Value = q.Value,
                AnswerEntities = q.QuestionAnswerEntities
                    .Select(x => new GetAnswerDto()
                    {
                        Id = x.AnswerEntity.Id,
                        Description = x.AnswerEntity.Description,
                        IdFile = x.AnswerEntity.IdFile,
                    }).ToList()
            }).ToList();

            return questionList;
        }

        public QuestionDto getById(int idQuestion)
        {
            QuestionEntity entity = _unitOfWork.QuestionRepository.FirstOrDefaultSelect(
                x => x.Id == idQuestion,
                s => s.Skill,
                i => i.FileEntity,
                a => a.QuestionAnswerEntities.Select(r => r.AnswerEntity));

            if (entity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            QuestionDto question = new QuestionDto()
            {
                Id = entity.Id,
                Description = entity.Description,
                IdSkill = entity.Skill?.Id,
                IdFile = entity.FileEntity?.Id,
                IsVisible = entity.IsVisible,
                Value = entity.Value,
                AnswerEntities = entity.QuestionAnswerEntities
                    .Select(x => new GetAnswerDto()
                    {
                        Id = x.AnswerEntity.Id,
                        Description = x.AnswerEntity.Description,
                        IdFile = x.AnswerEntity.IdFile
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

            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> Insert(QuestionFileDto questionDto)
        {
            string url = string.Empty;
            AddFileDto file = new AddFileDto()
            {
                FileName = questionDto.FileName,
                File = questionDto.File,
            };

            using (var db = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    QuestionEntity entity = new QuestionEntity() {
                        IsVisible = true,
                        Value = questionDto.Value,
                        Description = questionDto.Description,
                        SkillId = questionDto.IdSkill
                    };

                    if ( questionDto.File != null)
                    {
                        url = await _fileService.InsertFile(file, true);
                        GetFileDto dto = _fileService.getByUrl(url, true);
                        entity.IdFile = dto.Id;
                    }

                    _unitOfWork.QuestionRepository.Insert(entity);

                    await db.CommitAsync();
                    return await _unitOfWork.Save() > 0;
                }
                catch (BusinessException ex)
                {
                    _fileService.DeleteFile(url);
                    await db.RollbackAsync();
                    throw ex;
                }
                catch (Exception ex)
                {
                    _fileService.DeleteFile(url);
                    await db.RollbackAsync();
                    throw new Exception(GeneralMessages.Error500, ex);
                }
            }
        }
    }
}
