using CodingAssessment.Domain.Exceptions;
using FluentValidation;
using Newtonsoft.Json;

namespace CodingAssessment.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                if (error is ValidationException validationException)
                {
                    var errorResponse = new ErrorResponse
                    {
                        Code = "validation.error",
                        Message = "Validation Error",
                        Errors = (validationException.Errors.Select(error => new ErrorValidationResponse
                        {
                            Field = "validation.error.field." + error.PropertyName,
                            Message = error.ErrorMessage
                        }).ToList())
                    };

                    var errorResponseJson = JsonConvert.SerializeObject(errorResponse);

                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.ContentType = "application/json";

                    await response.WriteAsync(errorResponseJson);

                }
                else if (error is EntityNotFoundException entityNotFoundException)
                {
                    var entityClassName = entityNotFoundException.EntityClassName.ToLower();
                    var errorResponse = new ErrorResponse
                    {
                        Code = $"{entityClassName}.not.found.exception",
                        Message = entityNotFoundException.Message
                    };


                    var errorResponseJson = JsonConvert.SerializeObject(errorResponse);

                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.ContentType = "application/json";

                    await response.WriteAsync(errorResponseJson);
                }

                else if (error is EntityAlreadyExistsException entityAlreadyExistsException)
                {
                    var entityClassName = entityAlreadyExistsException.EntityClassName.ToLower();
                    var errorResponse = new ErrorResponse
                    {
                        Code = $"{entityClassName}.exists.exception",
                        Message = entityAlreadyExistsException.Message
                    };


                    var errorResponseJson = JsonConvert.SerializeObject(errorResponse);

                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.ContentType = "application/json";

                    await response.WriteAsync(errorResponseJson);
                }

                else if (error is EmptyContentException emptyContentException)
                {
                    response.StatusCode = StatusCodes.Status204NoContent;

                    await response.CompleteAsync();
                }

                else if (error is TechnicalException technicalException)
                {
                    var errorResponse = new ErrorResponse
                    {
                        Code = "technical.exception",
                        Message = technicalException.Message
                    };

                    var errorResponseJson = JsonConvert.SerializeObject(errorResponse);

                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.ContentType = "application/json";

                    await response.WriteAsync(errorResponseJson);
                }
                else
                {
                    var errorResponse = new ErrorResponse
                    {
                        Code = "unhandled.exception",
                        Message = error.Message
                    };

                    var errorResponseJson = JsonConvert.SerializeObject(errorResponse);

                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.ContentType = "application/json";

                    await response.WriteAsync(errorResponseJson);
                }
            }
        }
    }
    public class ErrorResponse
    {
        public string Code { get; set; }

        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ErrorValidationResponse> Errors { get; set; }
    }

    public class ErrorValidationResponse
    {
        public string Field { get; set; }

        public string Message { get; set; }
    }
}