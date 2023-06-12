namespace Core.Entities
{
    public class Project : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
    }
}
