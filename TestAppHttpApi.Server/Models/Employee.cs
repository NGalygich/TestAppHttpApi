using System.ComponentModel.DataAnnotations;

namespace TestAppHttpApi.Server.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PositionCode { get; set; }
        public string DepartmentCode { get; set; }
        public bool IsHidden { get; set; }
        public DateTime LastModified { get; set; }
    }
}
