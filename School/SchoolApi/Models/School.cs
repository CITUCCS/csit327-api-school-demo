namespace SchoolApi.Models
{
    public class School
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Motto { get; set; }
        public decimal AverageTuition { get; set; }

    }
}
