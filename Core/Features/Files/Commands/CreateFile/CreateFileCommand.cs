namespace Core.Features.Files.Commands.CreateFile
{
    public class CreateFileCommand
    {
        public string UserId { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
    }
}