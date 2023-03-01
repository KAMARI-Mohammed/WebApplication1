using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SectionProfesseur> SectionProfesseurs { get; set; }

        public ICollection<Student> Students { get; set; }


    }
}