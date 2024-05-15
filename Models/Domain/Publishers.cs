using System.ComponentModel.DataAnnotations;

namespace LAB_LTW_API.Models.Domain
{
    public class Publishers
    {
        [Key]
        public int PublishersId { get; set; }
        public string? Name { get; set; }
        public List<Books>? Books { get; set; }
    }
}
