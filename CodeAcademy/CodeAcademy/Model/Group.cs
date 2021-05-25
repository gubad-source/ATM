using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAcademy.Model
{
    [Serializable]
    class Group
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion


        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
