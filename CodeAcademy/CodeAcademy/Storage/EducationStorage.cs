using CodeAcademy.Concrate;
using CodeAcademy.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CodeAcademy.Storage
{
    class EducationStorage : IRules, ISaved, IEnumerable<Education>
    {
        Education[] data;
        public EducationStorage()
        {
            data = new Education[0];
        }
        public Education this[int index]
        {
            get
            {
                if (index > data.Length)
                {
                    throw new Exception("Mumkun deyil");
                }
                var founded = data[index];
                return founded;
            }
        }

        #region Saved

        public void Save(string path)
        {
            using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bnr = new BinaryFormatter();
                bnr.Serialize(stream, data);
            }
        }
        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bnr = new BinaryFormatter();
                data = (Education[])bnr.Deserialize(stream);
            }
        }

        #endregion

        #region Rules
        public bool Add(Education model)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = model;
            return true;
        }
        public bool Remove(Education model)
        {
            int index = Array.FindIndex(data, m => m.Equals(model));
            if (index == -1)
            {
                return false;
            }
            for (int i = index + 1; i < data.Length; i++)
            {
                data[i - 1] = data[i];

            }
            Array.Resize(ref data, data.Length - 1);
            return true;
        }

        public Education[] GetAll()
        {
            return data;
        }
        #endregion

        #region Students
        public IEnumerator<Education> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
