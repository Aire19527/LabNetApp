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
        #endregion

        public  QuestionServices(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
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
            {
                int fileId = entity.IdFile ?? 0;
                string url = _fileService.getById(fileId, true).Url;
                _fileService.DeleteFile(url);
            }


            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> Insert(QuestionFileDto questionDto)
        {
            AddFileDto file = new AddFileDto()
            {
                FileName = questionDto.FileName,
                File = questionDto.File,
            };

            FileEntity img = null;

            using (var db = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    if (questionDto.File != null)
                    {
                        img = _fileService.InsertFile(file);
                    }

                    QuestionEntity entity = new QuestionEntity() {
                        IsVisible = true,
                        Value = questionDto.Value,
                        Description = questionDto.Description,
                        //QuestionSkillEntity =
                        FileEntity = img,
                    };

                    // se ingresa el file

                    // se ingresa question, va tener que devolver el id o obtenerlo de alguna forma.
                    // o id no incremental, ponerlo a mano.
                    _unitOfWork.QuestionRepository.Insert(entity);

                    // se ingresa la questionSkill
                    // insert({idSkill, idQuestion})

                    // ingresar las RESPUESTAS=>
                    // primeramente sus files. y luego la respuesta. x4

                    await _unitOfWork.Save();
                    await db.CommitAsync();

                    return true;
                }
                catch (BusinessException ex)
                {
                    if (img!= null)
                    {
                        _fileService.DeleteFile(img.Url);
                    }
                    await db.RollbackAsync();

                    throw ex;
                }
                catch (Exception ex)
                {
                    if (img != null)
                    {
                        _fileService.DeleteFile(img.Url);
                    }
                    await db.RollbackAsync();

                    throw new Exception(GeneralMessages.Error500, ex);
                }
            }
        }
    }
}
