using System.ComponentModel.DataAnnotations;

namespace Taku.Community.Project.Domain.DomainEntities
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Action { get; set; }
        public double OldBalance { get; set; }
        public double NewBalance { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
