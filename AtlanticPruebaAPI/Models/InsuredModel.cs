using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlanticPruebaAPI.Models
{
    public class InsuredModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required]
        public string FirstLastName { get; set; }

        [Required]
        public string SecondLastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Value { get; set; }

        public string Observations { get; set; }


    }
}
