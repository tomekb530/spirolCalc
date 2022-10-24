using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace spirolCalc
{
    public class AlcoData 
    {
        public Utensil[] Utensils { get; set; }

        public Alcohol[] Alcohols { get; set; }
    }
    public class Utensil
    {
        public string Name { get; private set; }
        public double Size { get; private set; }

        public Alcohol[] exampleAlcohols { get; private set; }

    }
    public class Alcohol {
        public string Name { get; private set; }

        public double ABV { get; private set; }
    };
    public class CalcClass 
    {
        private object data;
        private string path = "data.txt";
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

        }
    }
}
