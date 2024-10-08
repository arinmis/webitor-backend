using System.Collections.Generic;
namespace Core.Entities
{
    public class Project : AuditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Collaborator> Collaborators { get; set; }
        public ICollection<File> Files { get; set; }
    }
}
