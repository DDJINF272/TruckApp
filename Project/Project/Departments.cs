using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Departments
    {
        public string name { get; set; }
        public string value { get; set; }
        public override string ToString()
        {
            return this.name;
        }
    }
}
