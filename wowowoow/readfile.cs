using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace wowowoow
{
    internal class readfile
    {

        private void json(string path)
        {
            string text = File.ReadAllText(path);
            Console.Clear();
            y.result = JsonConvert.DeserializeObject<List<eat>>(text);
            write();
        }
        private void txt(string path)
        {
            Console.Clear();
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i += 3)
            {
                eat bems = new eat(lines[i], lines[i + 1], lines[i + 2]);
                y.result.Add(bems);
            }
            write();
        }
        private void xml(string path)
        {
            Console.Clear();
            XmlSerializer xml = new XmlSerializer(typeof(eat));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                y.result = (List<eat>)xml.Deserialize(fs);
            }
            write();
        }
        public static void write()
        {
            Console.WriteLine("Сохранить файл - F1");
            Console.WriteLine("Закрыть программу - Escape");
            Console.WriteLine("_______________________________________________________________________________________");
            foreach (var zxc in y.result)
            {
                Console.WriteLine(zxc.name);
                Console.WriteLine(zxc.razmer);
                Console.WriteLine(zxc.vkus);
            }
        }
        public void opener(string path)
        {
            if (path.Contains("txt"))
                txt(path);
            else if (path.Contains("json"))
                json(path);
            else if (path.Contains("xml"))
                xml(path);
        }
    }
}
