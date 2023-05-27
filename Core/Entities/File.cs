
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entities
{
    public class File : AuditableBaseEntity
    {
        public string Path { get; set; }
        public string Content { get; set; }
    }
}