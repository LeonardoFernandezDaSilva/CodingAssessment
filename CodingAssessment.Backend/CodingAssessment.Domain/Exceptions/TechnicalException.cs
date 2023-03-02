namespace CodingAssessment.Domain.Exceptions
{
    public class TechnicalException : Exception
    {
        public TechnicalException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public TechnicalException(string message) : base(message)
        {

        }
    }
}
