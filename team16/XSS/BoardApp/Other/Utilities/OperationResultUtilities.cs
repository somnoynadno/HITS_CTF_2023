using BoardApp.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FeastHub.Common.Utilities
{
    public static class OperationResultUtilities
    {
        /// <summary>
        /// Used to log an exception describing an error and return corresponding result
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static ObjectResult DefaultEvaluator(Exception exception)
        {
            return exception switch
            {
                NotFoundException => new NotFoundObjectResult(exception.Message),
                AlreadyExistsException => new ConflictObjectResult(exception.Message),
                InvalidCredentialsException => new BadRequestObjectResult(exception.Message),
                BadTokenException => new BadRequestObjectResult(exception.Message),
                AccessDeniedException => new ObjectResult(exception.Message) { StatusCode = 403 },
                InvalidOperationException => new BadRequestObjectResult(exception.Message),
                IdentityException e => new BadRequestObjectResult(e.Errors),
                IAmATeapotException => new ObjectResult(exception.Message) { StatusCode = 418 },
                DbFailureException => new ObjectResult(exception.Message) { StatusCode = 500 },
                _ => new Func<ObjectResult>(() =>
                {
                    Console.WriteLine(exception);
                    return new ObjectResult("Something went wrong") { StatusCode = 500 };
                })()
            };
        }
    }
}
