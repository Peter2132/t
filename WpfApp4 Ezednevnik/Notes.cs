using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_Ezednevnik
{
    public class Note
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Note(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
