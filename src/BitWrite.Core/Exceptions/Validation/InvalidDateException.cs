using BitWrite.Core.Exceptions.Http;

namespace BitWrite.Core.Exceptions.Validation
{
    public class InvalidDateException : BadRequestException
    {
        public DateTime Date { get; }

        public InvalidDateException(DateTime date)
            : base($"Date: '{date}' is invalid.")
        {
            Date = date;
        }
    }

}