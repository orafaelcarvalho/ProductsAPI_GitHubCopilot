namespace ProductsAPI_GitHubCopilot.Domain.Exceptions
{
    public class RecordNotFoundException : BaseException
    {
        public RecordNotFoundException(string title, string message) : base(title, message)
        {
        }
    }
}
