using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork;
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
        private readonly IFileService _fileService;
        #endregion

        public AnswerServices(IUnitOfWork unitOfWork, IFileService fileSerivce)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileSerivce;
        }


        public List<GetAnswerDto> getAll()
        {
            IEnumerable<AnswerEntity> answerList = _unitOfWork.AnswerRepository.GetAll(x=> x.FileEntity);
            List<GetAnswerDto> answers = answerList.Select(a => new GetAnswerDto()
            {
                Id = a.Id,
                Description = a.Description,
                IdFile = a.IdFile,
                urlFile = a.FileEntity?.Url

            }).ToList();

            return answers;
        }


        public async Task<int> Insert(AnswerFileDto answerFile)
        {

            AddFileDto file = new AddFileDto()
            {
                File = answerFile.File,
            };
            FileEntity img = null;


            using (var dbA = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    if (answerFile.File != null)
                    {
                        img = _fileService.InsertFile(file);
                    }

                    AnswerEntity entity = new AnswerEntity()
                    {
                        Description = answerFile.Description,
                        FileEntity = img
                    };

                    _unitOfWork.AnswerRepository.Insert(entity);
                    await _unitOfWork.Save();

                    await dbA.CommitAsync();

                    return entity.Id;
                }
                catch (BusinessException ex)
                {
                    if (img != null)
                    {
                        _fileService.DeleteFile(img.Url);
                    }

                    await dbA.RollbackAsync();

                    throw ex;
                }
                catch (Exception ex)
                {
                    if (img != null)
                    {
                        _fileService.DeleteFile(img.Url);
                    }
                    await dbA.RollbackAsync();

                    throw new Exception(GeneralMessages.Error500, ex);
                }
            }
        }

        public async Task<AnswerEntity> InsertToQuestion(AnswerFileDto answerFile)
        {

            AddFileDto file = new AddFileDto()
            {
                File = answerFile.File,
            };
            FileEntity img = null;

            try
            {
                if (answerFile.File != null)
                {
                    img = _fileService.InsertFile(file);
                }

                AnswerEntity entity = new AnswerEntity()
                {
                    Description = answerFile.Description,
                    FileEntity = img
                };

                _unitOfWork.AnswerRepository.Insert(entity);
                await _unitOfWork.Save();

                return entity;
            }
            catch (BusinessException ex)
            {
                if (img != null)
                    _fileService.DeleteFile(img.Url);

                throw ex;
            }
            catch (Exception ex)
            {
                if (img != null)
                    _fileService.DeleteFile(img.Url);

                throw new Exception(GeneralMessages.Error500, ex);
            }

        }


        public async Task<bool> Delete(int id)
        {
            AnswerEntity? AnswerEntity = _unitOfWork.AnswerRepository.FirstOrDefault((x) => x.Id == id);

            if (AnswerEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            if (AnswerEntity.IdFile != null)
                await _fileService.Delete((int)AnswerEntity.IdFile);

            _unitOfWork.AnswerRepository.Delete(AnswerEntity);

            return await _unitOfWork.Save() > 0;
        }

        public GetAnswerDto getById(int id)
        {
            AnswerEntity entity = _unitOfWork.AnswerRepository.FirstOrDefault(x => x.Id == id,
                                                                              f=> f.FileEntity);

            GetAnswerDto answer = new GetAnswerDto()
            {
                Id = entity.Id,
                Description = entity.Description,
                IdFile = entity.IdFile,
                urlFile = entity.FileEntity?.Url
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
                IsCorrect = add.isCorrect
            });

            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> DeleteAnswerToQuestion(int idQuestion, int idAnswer)
        {
            if (idQuestion == null || idAnswer == null)
                throw new BusinessException("No se ha indicado pregunta o respuesta.");

            QuestionAnswerEntity? QuestionAnswer = _unitOfWork.QuestionAnswerRepository.FirstOrDefault(p => p.QuestionId == idQuestion &&
                                                                                        p.AnswerId == idAnswer);

            if (QuestionAnswer == null)
                throw new BusinessException();

            _unitOfWork.QuestionAnswerRepository.Delete(QuestionAnswer);

            return await _unitOfWork.Save() > 0;
        }
    }
}
