using System.ComponentModel.DataAnnotations;

namespace JQgridTest.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name ="姓名")]
        public string Name { get; set; }

        [Display(Name = "密码")]
        public string Password { get; set; } 
    }
}