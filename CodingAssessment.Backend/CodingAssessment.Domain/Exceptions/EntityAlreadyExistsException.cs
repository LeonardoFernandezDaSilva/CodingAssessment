using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessment.Domain.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public string EntityClassName { get; private set; }

        public EntityAlreadyExistsException(string entityClassName, string message, Exception innerException) : base(message, innerException)
        {
            this.EntityClassName = entityClassName;
        }
        public EntityAlreadyExistsException(string entityClassName, string message) : base(message)
        {
            this.EntityClassName = entityClassName;
        }

    }
}
