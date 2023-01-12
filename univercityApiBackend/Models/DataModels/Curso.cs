

using System.ComponentModel.DataAnnotations;


namespace univercityApiBackend.Models.DataModels
{

    public enum Level
    {
        Basic,Medium,Advanced
    }
    public class Curso: BaseEntity
    {
        [Required,StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string LongDescription { get; set; } = string.Empty;
        [Required]
        public string TargetAudiences { get; set; } = string.Empty;
        [Required]
        public string Objectives { get; set; } = string.Empty;
        [Required]
        public string Requirements { get; set; } = string.Empty;
        
        public Level Level { get; set; } = Level.Basic;
       
   
       


}
}
