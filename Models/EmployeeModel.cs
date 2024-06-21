using System.ComponentModel.DataAnnotations;

namespace CRUDWithADODotNet.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string City { get; set; }
    }
}
