using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wowowoow
{
    internal class save
    {
            string save_path = hihihi();
        public void finalsave()
        {
            if (save_path.Contains("txt"))
                save_txt();
            else if (save_path.Contains("json"))
                save_json();
            else if (save_path.Contains("xml"))
                save_xml();
        }
        private void save_txt()
        {
            List<string> savefile = new ();
            foreach (var aga in y.result)
            {
                savefile.Add(aga.name);
                savefile.Add(aga.razmer);
                savefile.Add(aga.vkus);
            }
            File.WriteAllLines(save_path, savefile);
        }
        private void save_json()
        {
            string json = JsonConvert.SerializeObject(y.result);
            File.WriteAllText(save_path, json);
        }
        private void save_xml()
        {
            XmlSerializer xml = new XmlSerializer(typeof(eat));
            using (FileStream fs = new FileStream(save_path, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, y.result);
            }
        }
        private static string hihihi()
        {
            Console.WriteLine("Введите путь до файла (вместе с названием), куда вы хотите сохранить текст");
            Console.WriteLine("__________________________________________________________________________________________________");
            string a = Console.ReadLine();
            return a;
        }
    }
}
