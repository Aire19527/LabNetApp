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
        Task<bool> InsertFile(AddFileDto add, bool isImg);
        Task<bool> UpdateFile(UpdateFileDto upd, bool isImg);
        Task<bool> DeleteFile(int id);
        GetFileDto getById(int id, bool isImg);
        

    }
}
