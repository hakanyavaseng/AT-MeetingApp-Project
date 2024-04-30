namespace MeetingApp.Core.Entities
{
    public class EntityBase : IEntityBase
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime RegisteredDate { get; set; }
        public virtual bool? IsActive { get; set; }
    }
}
