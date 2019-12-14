using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;




namespace UWP.Model
{
    public class Soldier
    {
        public String Name { get; set; }

        public String Dignity { get; set; }

        public int Salary { get; set; }
    }
}
