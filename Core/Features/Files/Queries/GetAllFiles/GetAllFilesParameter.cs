using Core.Filters;

namespace Core.Features.Files.Queries.GetAllFiles
{
    public class GetAllFilesParameter : RequestParameter
    {
        public string UserId { get; set; }



        public GetAllFilesParameter(string userId) : base()
        {
            this.UserId = userId;
        }

    }
}
