using System.ComponentModel.DataAnnotations;

namespace GoatFarm.Management.API.GoatManagement.Models.Commands
{
    public class AddNewGoatCommand
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string TagNumber { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [MaxLength(256)]
        public string IdentityDescription { get; set; }

        public Guid PictureId { get; set; }
        public long DateOfBirthInUnixTimeMilliseconds {get; set;} 
    }
}
