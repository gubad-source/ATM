using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAcademy.Model
{
    [Serializable]
    class Education:IEquatable<Education>
    {
        public Group Group { get; set; }
        public Student Student { get; set; }

        public bool Equals(Education other)
        {
            return Group.Id == other.Group.Id && Student.Id == other.Student.Id;
        }
        public override string ToString()
        {
            return $"{Group.Name}|{Student.Name}|{Student.Surname}|{Student.Payment}";
        }
    }
}
