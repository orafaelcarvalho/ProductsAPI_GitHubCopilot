namespace ProductsAPI_GitHubCopilot.Domain.Exceptions
{
    public class InvalidEntityException : BaseException
    {
        public InvalidEntityException(string title, string message) : base(title, message)
        {
        }
    }
}
