namespace SmsHub.Api.Utility
{
    public class FileResultContentTypeAttribute:Attribute
    {
        public string ContentType { get; }
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }
    }
}
