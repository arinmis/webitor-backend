namespace Core.Entities
{
    public class Collaborator : AuditableBaseEntity
    {
        public string OwnerId { get; set; }
        public string ProjectName { get; set; }
        public string CollaboratorId { get; set; }
    }
}
