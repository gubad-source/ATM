using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAcademy.Model
{
    [Serializable]
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Payment { get; set; }

        public override string ToString()
        {
            return $"{Name}|{Surname}|{Payment}";
        }
    }
}
