using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Lab.Domain.Dto.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces


{
    public interface IFileService
    {
        Task<string> InsertFile(AddFileDto add, bool isImg,IUnitOfWork unit);
        Task<bool> UpdateFile(UpdateFileDto upd, bool isImg);
        void DeleteFile(string path);
        GetFileDto getById(int id, bool isImg);

        GetFileDto getByUrl(string url, bool isImg);


    }
}
