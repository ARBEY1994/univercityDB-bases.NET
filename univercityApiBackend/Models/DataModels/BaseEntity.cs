
using System.ComponentModel.DataAnnotations;

namespace univercityApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string CreateBy { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public string UpDatedBy { get; set; } = string.Empty;
        public DateTime? UpDateAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted {get; set;} = false;
    }
}
