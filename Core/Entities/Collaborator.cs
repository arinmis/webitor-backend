namespace Core.Entities
{
    public class Collaborator : AuditableBaseEntity
    {
        public string ProjectId { get; set; }
        public string CollaboratorId { get; set; }
    }
}
