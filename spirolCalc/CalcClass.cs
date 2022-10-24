using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace spirolCalc
{
    public class AlcoData 
    {
        public List<Utensil> Utensils { get; set; }

        public List<Alcohol> Alcohols { get; set; }
    }
    public class Utensil
    {
        public string Name { get; set; }
        public double Size { get; set; }

        public List<string> exampleAlcohols { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
    public class Alcohol {
        public string Name { get; set; }

        public double ABV { get; set; }

        public override string ToString()
        {
            return Name;
        }
    };
    public class CalcClass 
    {
        public AlcoData data;
        private string path = "data.json";
        private string datastring;
        private AlcoData InitFile()
        {
            //if file exists, read it
            if (File.Exists(path))
            {
                datastring = File.ReadAllText(path);
            }
            else
            {
                throw new FileNotFoundException("File not found");
            }
            if (datastring != null)
            {
                return JsonSerializer.Deserialize<AlcoData>(datastring);
            }
            else
            {
                throw new NullReferenceException("Data is null");
            }
        }
        public CalcClass()
        {
            this.data = InitFile();
        }
    }
}
