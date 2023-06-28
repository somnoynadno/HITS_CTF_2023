namespace BoardApp.Models.Exceptions
{
    public class DbFailureException : Exception
    {
        public DbFailureException()
        {
        }

        public DbFailureException(string? message) : base(message)
        {
        }

        public DbFailureException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
