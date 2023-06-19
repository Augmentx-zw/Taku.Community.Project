using System.ComponentModel.DataAnnotations;

namespace Taku.Community.Project.Domain.DomainEntities
{
    public class Card
    {
        [Key]
        public Guid CardId { get; set; }
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public string? CardName { get; set; }
        public int CardNumber { get; set; }
        public int CardCVV { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
