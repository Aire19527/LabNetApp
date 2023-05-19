using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.Helpers
{
    public class ImageHelper
    {
        public static bool ValidImageExtension(string currentExtension)
        {
            bool result = false;
            string[] validExtensions =
            {
                ".jpg",".png",".jpeg"
            };

            foreach (string extension in validExtensions)
            {
                if (currentExtension.Equals(extension))
                    result = true;
            }

            return result;
        }

        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";
        }
    }
}
