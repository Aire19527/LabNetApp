namespace Common.Helpers
{
    public class FileHelper
    {

        public static bool ValidExtension(string currentExtension, bool isImage)
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

        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";
        }
    }

}
