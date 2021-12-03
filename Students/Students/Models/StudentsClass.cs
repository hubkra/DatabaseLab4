using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class StudentsClass
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public int Pesel { get; set; }
    }


    }
