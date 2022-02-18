using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Logger<T>
    {
        private string jsonFileName;

        public Logger(string jsonFileName)
        {
            if (string.IsNullOrEmpty(jsonFileName))
            {
                throw new ArgumentException();
            }

            this.jsonFileName = jsonFileName + ".xml";
        }


        public void Tracker(object obj)
        {
            var type = typeof(T);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
