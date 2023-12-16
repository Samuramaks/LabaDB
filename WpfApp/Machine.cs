using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class Machine
    {
        public int id { get; set; }
        public string name { get; set; }

        public string type_cnc { get; set; }
        public override string ToString() => $"{name}";

        public Machine(int id, string name, string type_cnc) 
        {
            this.id = id ;
            this.name = name ;
            this.type_cnc = type_cnc ;
        }
    }
}
