namespace ProductsAPI_GitHubCopilot.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public string Title { get; private set; }
        public new string Message { get; private set; }

        public BaseException(string title, string message) : base(message)
        {
            Title = title;
            Message = message;
        }
    }
}
