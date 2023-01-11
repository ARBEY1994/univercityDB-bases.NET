
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace univercityApiBackend.Models.DataModels
{
    public class Curso: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string Descripcion_corta { get; set; } = string.Empty;

        [Required]
        public string Descripcion_larga { get; set; } = string.Empty;
        [Required]
        public string Publico_objetivo { get; set; } = string.Empty;
        [Required]
        public string Objetivos { get; set; } = string.Empty;
        [Required]
        public string Requisitos { get; set; } = string.Empty;
        [Required]
        public  string Nivel { get; set; } = string.Empty;
       
   
       


}
}
