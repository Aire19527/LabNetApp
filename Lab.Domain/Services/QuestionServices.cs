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

        public QuestionDto getById(int idQuestion)
        {
            QuestionEntity entity = _unitOfWork.QuestionRepository.FirstOrDefault(x => x.Id == idQuestion,
                                                                                  s => s.Skill,
                                                                                  i => i.FileEntity,
                                                                                  a => a.AnswerEntities.Select(x => x.IdQuestion == idQuestion));

            QuestionDto question = new QuestionDto()
            {
                Id = entity.Id,
                Description = entity.Description,
                IdSkill = entity.Skill.Id,
                IdFile = entity.FileEntity.Id,
       
                IsVisible = entity.IsVisible,
                Value = entity.Value,
                AnswerEntities = entity.AnswerEntities.Select(x => new GetAnswerDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    IsCorrect = x.IsCorrect,
                    IdFile = x.IdFile
                }).ToList()
            };

            return question;
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
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

                    url = await _fileService.InsertFile(file,true,_unitOfWork);
                    GetFileDto dto = _fileService.getByUrl(url,true);

                    QuestionEntity entity = new QuestionEntity() {
                        IdFile = dto.Id,
                        IsVisible = true,
                        Value = questionDto.Value,
                        Description = questionDto.Description,
                        SkillId = questionDto.IdSkill// hay doble idSkill en db
                    };

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

        public bool Update(QuestionDto questionDto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateImage(UpdateFileDto fileDto)
        {
            _fileService.UpdateFile(fileDto, isImg: true);
            return true;
        }
    }
}
