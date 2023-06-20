using System.ComponentModel.DataAnnotations;

namespace Taku.Community.Project.Domain.DomainEntities
{
    public class SubcribedCommunityProject
    {
        [Key]
        public Guid SubcribedCommunityProjectId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid CardId { get; set; }
        public Guid UserId { get; set; }
        public bool Recurring { get; set; }
        public int RecurringDays { get; set; }
        public string? Action { get; set; }
        public double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
