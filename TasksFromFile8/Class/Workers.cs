using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFromFile8.Class
{
    internal class Workers
    {
        public string Name { get; set; }
        public string Work {get; set; }
        public Workers(string name, string work)
        {
            Name = name;
            Work = work;
        }
    }
}
