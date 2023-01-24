
using System.ComponentModel.DataAnnotations;

namespace univercityApiBackend.Models.DataModels
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name { get; set; }= string.Empty;

        public ICollection<Curso> Curso { get; set; }= new List<Curso>();
    }
}
