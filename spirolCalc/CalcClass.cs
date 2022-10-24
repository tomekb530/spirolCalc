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

        public override string ToString()
        {
            return Name;
        }

    }
    public class Alcohol {
        public string Name { get; set; }

        public double ABV { get; set; }

        public string PrefferedUtensil { get; set; }

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
                throw new FileNotFoundException("Nie znaleziono presetów, ładuję bez nich!");
            }
            if (datastring != null)
            {
                return JsonSerializer.Deserialize<AlcoData>(datastring);
            }
            else
            {
                throw new NullReferenceException("Plik z presetami jest pusty, ładuję bez nich!");
            }
        }
        public CalcClass()
        {
            this.data = InitFile();
        }

        public List<Alcohol> GetExampleAlcohols(string name)
        {
            return data.Alcohols.Where(x => x.PrefferedUtensil == name).ToList();
        }
        public static double Calculate(double size, double ABV, double amount)
        {
            return (size * ABV) / 100 * amount;
        }
    }
}
