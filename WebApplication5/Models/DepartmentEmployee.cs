using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [Table("DepartmentEmployees")]
    public class DepartmentEmployee
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Employee")]
        [MaxLength(25)]
        public string? Employee { get; set; }

        [Column("Department")]
        [MaxLength(25)]
        public string? Department { get; set; }

        [Column("Salary", TypeName = "decimal(18,0)")]
        public decimal? Salary { get; set; }
    }
}
