namespace MeetingApp.Core.Entities
{
    public class EntityBase : IEntityBase
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual DateTime RegisteredDate { get; set; } = DateTime.Now;
        public virtual bool? IsActive { get; set; } = true;
    }
}
