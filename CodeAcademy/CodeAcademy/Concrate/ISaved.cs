using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAcademy.Concrate
{
    interface ISaved
    {
        void Save(string path);
        void Load(string path);
    }
}
