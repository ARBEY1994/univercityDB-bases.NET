using System.ComponentModel.DataAnnotations;

namespace univercityApiBackend.Models.DataModels
{
    public class Chapter:BaseEntity
    {
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }= new Curso();
        [Required]
        public string List = string.Empty;

    }
}
