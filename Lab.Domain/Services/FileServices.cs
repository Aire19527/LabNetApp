using Common.Exceptions;
using Common.Helpers;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.File;
using Lab.Domain.Dto.ProfileImage;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Lab.Domain.Services
{
    public class FileServices : IFileService
    {

        #region Attributes
        private IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion


        #region Builder
        public FileServices(IUnitOfWork unitOfWork, IConfiguration config,
            IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        public GetFileDto getById(int id,bool isImg)
        {
            FileEntity file = _unitOfWork.FileRepository.FirstOrDefault(f => f.Id == id);
            if (file == null)
                throw new BusinessException("El id no existe");
            GetFileDto fileDto = new GetFileDto();
            fileDto.Id = file.Id;
            fileDto.FileName = file.FileName;
            fileDto.CreatedAt = file.CreatedAt;
            if (isImg) fileDto.Url = getImage(file.Url);
            else fileDto.Url = getResumee(file.Url);
            return fileDto;
        }

        public GetFileDto getByUrl(string url, bool isImg)
        {
            FileEntity file = _unitOfWork.FileRepository.FirstOrDefault(f => f.Url == url);
            if (file == null)
                throw new BusinessException("El id no existe");
            GetFileDto fileDto = new GetFileDto();
            fileDto.Id = file.Id;
            fileDto.FileName = file.FileName;
            fileDto.CreatedAt = file.CreatedAt;
            if (isImg) fileDto.Url = getImage(file.Url);
            else fileDto.Url = getResumee(file.Url);
            return fileDto;
        }

        public async Task<string> InsertFile(AddFileDto add, bool isImg)

        {
            FileEntity file = new FileEntity()
            {
                FileName = add.FileName,
                Url = UploadFile(add.File, isImg),
                CreatedAt = DateTime.Now
            };
            _unitOfWork.FileRepository.Insert(file);

            await _unitOfWork.Save();

            return file.Url;
        }

        public async Task<bool> UpdateFile(UpdateFileDto upd, bool isImg)
        {
            FileEntity file = _unitOfWork.FileRepository.FirstOrDefault(x => x.Id == upd.Id);
            if (file != null)
            {
                DeleteFile(file.Url); //elimina del servidor la imagen actual
                file.FileName = upd.FileName;
                file.Url = UploadFile(upd.File, isImg);
                return await _unitOfWork.Save() > 0;
            }
            return false;
        }

        public Task<bool> DeleteFile(int id)
        {
            throw new NotImplementedException();
        }


        #region privateMethods

        private string UploadFile(IFormFile add, bool isImg)
        {
            string Url = string.Empty;

            if (add.FileName.Length > 3000000)
                throw new BusinessException("The file size is too big!: [max 3 MB]");

            //Comprobar que el archivo sea imagen o documento
            string extension = Path.GetExtension(add.FileName);

            if (!ValidExtension(extension, isImg))
                throw new BusinessException("Extension invalida");

            if (isImg)
                Url = $"{_config.GetSection("PathFiles").GetSection("ProfilePicture").Value}";
            else
                Url = $"{_config.GetSection("PathFiles").GetSection("Resumee").Value}";

            if (!Directory.Exists(Url))
                Directory.CreateDirectory(Url);

            string uploads = Path.Combine(_webHostEnvironment.WebRootPath, Url);
            string uniqueFileName = GetUniqueFileName(add.FileName);
            string pathFinal = $"{uploads}/{uniqueFileName}";

            using (var stream = new FileStream(pathFinal, FileMode.Create))
            {
                add.CopyTo(stream);
            }
            return $"{Url}/{uniqueFileName}";
        }


        public void DeleteFile(string path)
        {
            string pathFull = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (File.Exists(pathFull))
                File.Delete(pathFull);
        }

        private string getImage(string? img)
        {
            string path = string.Empty;
            if (string.IsNullOrEmpty(img))
            {
                path = $"{_webHostEnvironment.WebRootPath}/{_config.GetSection("PathFiles").GetSection("NoImage").Value}";
            }
            else
            {
                path = $"{_webHostEnvironment.WebRootPath}/{img}";
            }
            return path;
        }



        private string getResumee(string? resumee)
        {
            string path = string.Empty;
            if (string.IsNullOrEmpty(resumee))
            {
                path = "";
            }
            else
            {
                path = $"/{resumee}";
            }
            return path;
        }



        private static bool ValidExtension(string currentExtension, bool isImage)
        {
            bool result = false;

            if (isImage)
            {
                string[] validExtensions =
                {
                    ".jpg",".png",".jpeg",".webp"
                };

                foreach (string extension in validExtensions)
                {
                    if (currentExtension.Equals(extension))
                        result = true;
                }

                return result;
            }
            else
            {
                string[] validExtensions =
                {
                    ".pdf",".docx"
                };

                foreach (string extension in validExtensions)
                {
                    if (currentExtension.Equals(extension))
                        result = true;
                }

                return result;
            }
        }

        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";
        }



        #endregion


    }
}
