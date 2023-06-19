using System.ComponentModel.DataAnnotations;

namespace Taku.Community.Project.Domain.DomainEntities
{
    public class CommunityProject
    {
        [Key]
        public Guid ProjectId { get; set; }
        public string? Name { get; set; }
        public double FundsRequired { get; set; }
        public double FundsRaised { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
