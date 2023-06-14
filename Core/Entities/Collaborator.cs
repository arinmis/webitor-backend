using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Collaborator : AuditableBaseEntity
    {
        public string CollaboratorId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
