namespace Common.Utils.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() : base() 
        {
        }
        public BusinessException(string message) : base(message)
        {
        }
    }
}