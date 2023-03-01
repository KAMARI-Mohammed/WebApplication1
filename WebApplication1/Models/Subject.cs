using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Subject
    {

        public int Id { get; set; }
        public string subjectName { get; set; }

        public string subjectDescription { get; set; }

        public ICollection<SubjectProfessor> SubjectProfessors { get; set; }

        public ICollection<Note> Notes { get; set; }




    }
}