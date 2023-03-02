namespace CodingAssessment.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string EntityClassName { get; private set; }

        public EntityNotFoundException(){}
        public EntityNotFoundException(string entityClassName, string message, Exception innerException) : base(message, innerException)
        {
            this.EntityClassName = entityClassName;
        }
        public EntityNotFoundException(string entityClassName, string message) : base(message)
        {
            this.EntityClassName = entityClassName;
        }

    }
}
