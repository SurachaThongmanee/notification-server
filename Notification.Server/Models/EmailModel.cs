namespace Notification.Server.Models
{
    public class Response<T>
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
    public class EmailModel
    {
        public List<string> FileName { get; set; }
        public string? ToEmail { get; set; }
        public string? ToEmailBody { get; set; }
        public EmailModel()
        {
            FileName = new List<string>();
        }
    }
}
