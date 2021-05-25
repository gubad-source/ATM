using CodeAcademy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAcademy.Concrate
{
    interface IRules
    {
        bool Add(Education model);
        bool Remove(Education model);
        Education[] GetAll();
    }
}
