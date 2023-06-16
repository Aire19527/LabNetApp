﻿using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Lab.Domain.Dto.File;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces


{
    public interface IFileService
    {
        Task<string> InsertFile(AddFileDto add, bool isImg);
        Task<bool> UpdateFile(UpdateFileDto upd, bool isImg);
        void DeleteFile(string path);
        GetFileDto getById(int id, bool isImg);

        GetFileDto getByUrl(string url, bool isImg);

        public string UploadFile(IFormFile add, bool isImg);



    }
}
