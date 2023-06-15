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
        bool UploadFile(AddFileDto add);

    }
}
