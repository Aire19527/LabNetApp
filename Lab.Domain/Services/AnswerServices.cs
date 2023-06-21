using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.AnswerQuestion;
using Lab.Domain.Dto.File;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.Question;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class AnswerServices : IAnswerService
    {
        #region builder
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileSerivce;
        #endregion

        public AnswerServices(IUnitOfWork unitOfWork, IFileService fileSerivce)
        {
            _unitOfWork = unitOfWork;
            _fileSerivce = fileSerivce; 
        }


        public List<GetAnswerDto> getAll()
        {
            IEnumerable<AnswerEntity> answerList = _unitOfWork.AnswerRepository.GetAll();
            List<GetAnswerDto> answers = answerList.Select(a => new GetAnswerDto()
            {
                Id = a.Id,
                Description = a.Description,
                IdFile = a.IdFile
            }).ToList();

            return answers;
        }


        public async Task<bool> Insert(AnswerFileDto answerFile)
        {

            
                string url = string.Empty;
                AddFileDto file = new AddFileDto()
                {
                    FileName = answerFile.FileName,
                    File = answerFile.File,
                };

                using (var dbA = await _unitOfWork.BeginTransactionAsync())
                {
                    try
                    {


                    AnswerEntity entity = new AnswerEntity()
                        {
                            Description = answerFile.Description,
                        };

                        if (answerFile.File != null)
                        {
                            url = await _fileSerivce.InsertFile(file, true);
                            GetFileDto dto = _fileSerivce.getByUrl(url, true);
                            entity.IdFile = dto.Id;
                        }

                    _unitOfWork.AnswerRepository.Insert(entity);

                        await dbA.CommitAsync();
                        return await _unitOfWork.Save() > 0;
                    }
                    catch (BusinessException ex)
                    {
                    _fileSerivce.DeleteFile(url);
                        await dbA.RollbackAsync();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        _fileSerivce.DeleteFile(url);
                        await dbA.RollbackAsync();
                        throw new Exception(GeneralMessages.Error500, ex);
                    }

                }
            
        }

        public async Task<bool> Delete(int id)
        {
            AnswerEntity? AnswerEntity = _unitOfWork.AnswerRepository.FirstOrDefault((x) => x.Id == id);

            if (AnswerEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.AnswerRepository.Delete(AnswerEntity);

            return await _unitOfWork.Save() > 0;
        }

        public GetAnswerDto getById(int id)
        {
            AnswerEntity entity = _unitOfWork.AnswerRepository.FirstOrDefault(x => x.Id == id);

            GetAnswerDto answer = new GetAnswerDto()
            {
                Id = entity.Id,
                Description = entity.Description,
                IdFile = entity.IdFile,
            };

            return answer;
        }

        public async Task<bool> InsertAnswerInQuestion(AddAnswerQuestion add)
        {
            if (add.IdAnswer == null || add.IdQuestion == null)
                throw new BusinessException("No se ha indicado pregunta y/o respuesta.");

            AnswerEntity Answer = _unitOfWork.AnswerRepository.FirstOrDefault(x => x.Id == add.IdAnswer);
            QuestionEntity Question = _unitOfWork.QuestionRepository.FirstOrDefault(x => x.Id == add.IdQuestion);

            if (Answer == null || Question == null)
                throw new BusinessException("Pregunta y/o respuesta no existente.");


            _unitOfWork.QuestionAnswerRepository.Insert(new QuestionAnswerEntity()
            {
                AnswerId = add.IdAnswer,
                QuestionId = add.IdQuestion,
                isCorrect = add.isCorrect
            });

            return await _unitOfWork.Save() > 0;
        }



    }
}
