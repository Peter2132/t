using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_Ezednevnik
{
    public static class SerandDeser
    {
        public static void Serialize(Dictionary<DateTime, List<Note>> notes, string fileName)
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(fileName, json);
        }

        public static Dictionary<DateTime, List<Note>> Deserialize(string fileName)
        {
             string json = File.ReadAllText(fileName);
             return JsonConvert.DeserializeObject<Dictionary<DateTime, List<Note>>>(json);
            
        }
    }
}
