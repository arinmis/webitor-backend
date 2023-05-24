
namespace Core.DTOs.File
{
    public class CreateFileRequest
    {
        public string Content { get; set; }
        public string Path { get; set; }
        public string UserId { get; set; }
    }
}
