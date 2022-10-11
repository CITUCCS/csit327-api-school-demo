using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Dtos.School
{
    public class SchoolCreationDto
    {
        [Required(ErrorMessage = "The school name is required.")]
        [MaxLength(30, ErrorMessage = "Maximum lenghth for the name of the school is 30 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The school address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "The school motto is required.")]
        public string? Motto { get; set; }

        [Required(ErrorMessage = "The school average tuition is required.")]
        [Range(10, double.MaxValue, ErrorMessage = "School tuition must be at least 10.")]
        public decimal AverageTuition { get; set; }
    }
}
