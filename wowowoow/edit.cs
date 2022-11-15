using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowowoow
{
    internal class edit
    {
        string stroka_after = "";
        string stroka_before = "";
        int stop = 0;
        ConsoleKeyInfo key = new ConsoleKeyInfo((char)ConsoleKey.A, ConsoleKey.A, false, false, false);
        int stroka = 3;
        int stolbec = 0;
        
        private void goup()
        {
            stolbec = 0;
            stroka--;
            if (stroka == 2)
                stroka = 3;
        }
        private void godown()
        {
            stolbec = 0;
            stroka++;
            if ((stroka - 2) > (y.result.Count * 3))
                stroka = (y.result.Count * 3) + 2;
        }
        private void goright()
        {
            string b = "";
            if (stroka % 3 == 0)
            {
                b += Convert.ToString(y.result[(stroka - 3) / 3].name);
            }
            else if ((stroka - 1) % 3 == 0)
            {
                b += Convert.ToString(y.result[(stroka - 3) / 3].razmer);
            }
            else if ((stroka - 2) % 3 == 0)
            {
                b += Convert.ToString(y.result[(stroka - 3) / 3].vkus);
            }
            int a = b.Length;
            stolbec++;
            if (stolbec > a)
                stolbec = a;
        }
        private void goleft()
        {
            stolbec--;
            if (stolbec < 0)
                stolbec = 0;
        }
        private void delete()
        {
                try
                {
            if (stroka % 3 == 0)
            {
                    string b = Convert.ToString(y.result[(stroka - 3) / 3].name);
                    b = b.Remove(stolbec, 1);
                    y.result[(stroka - 3) / 3].name = b;
            }
            else if ((stroka - 1) % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3 ].razmer);
                b = b.Remove(stolbec, 1);
                y.result[(stroka - 3) / 3].razmer = b;
            }
            else if ((stroka - 2) % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3].vkus);
                b = b.Remove(stolbec, 1);
                y.result[(stroka - 3) / 3].vkus = b;
            }
                }
                catch (Exception) {}
            stolbec -= 1;
        }
        private void add()
        {
            if (stroka % 3 == 0)
            {
                string button = Convert.ToString(key.Key);
                string b = Convert.ToString(y.result[(stroka - 3) / 3].name);
                stroki_before_after(b);
                b = zapis_v_stroky(b);
                y.result[(stroka - 3) / 3].name = b;
            }
            else if ((stroka - 1) % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3].razmer);
                stroki_before_after(b);
                b = zapis_v_stroky(b);
                y.result[(stroka - 3) / 3].razmer = b;
            }
            else if ((stroka - 2) % 3 == 0)
            {

                string b = Convert.ToString(y.result[(stroka - 3) / 3].vkus);
                string stroka_after = b.Remove(0, stolbec);
                string stroka_before = b.Remove(stolbec, b.Length - stolbec);
                stroki_before_after(b);
                b = zapis_v_stroky(b);
                y.result[(stroka - 3) / 3].vkus = b;
            }
            stolbec += 1;
        }
        private void space()
        {
            if (stroka % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3].name);
                stroki_before_after(b);
                b = space_stroka(b);

                y.result[(stroka - 3) / 3].name = b;
            }
            else if ((stroka - 1) % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3].razmer);
                stroki_before_after(b);
                b = space_stroka(b);
                y.result[(stroka - 3) / 3].razmer = b;
            }
            else if ((stroka - 2) % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3].vkus);
                stroki_before_after(b);
                b = space_stroka(b);
                y.result[(stroka - 3) / 3].vkus = b;
            }

        }
        private void digits()
        {
            if (stroka % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3].name);
                stroki_before_after(b);
                string button = Convert.ToString(key.Key);
                button = button.Remove(0, 1);
                b = stroka_before + button + stroka_after;
                y.result[(stroka - 3) / 3].name = b;
            }
            else if ((stroka - 1) % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3].razmer);
                stroki_before_after(b);
                string button = Convert.ToString(key.Key);
                button.Remove(0, 1);
                b = stroka_before + button + stroka_after;
                y.result[(stroka - 3) / 3].razmer = b;
            }
            else if ((stroka - 2) % 3 == 0)
            {
                string b = Convert.ToString(y.result[(stroka - 3) / 3].vkus);
                stroki_before_after(b);
                string button = Convert.ToString(key.Key);
                button.Remove(0, 1);
                b = stroka_before + button + stroka_after;
                y.result[(stroka - 3) / 3].vkus = b;
            }
        }
        private void stroki_before_after(string b)
        {
            stroka_after = b.Remove(0, stolbec);
            stroka_before = b.Remove(stolbec, b.Length - stolbec);
        }
        private string zapis_v_stroky(string b)
        {
            string button = Convert.ToString(key.Key);
            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
            {
                b = stroka_before + button.ToUpper() + stroka_after;
            }
            else
            {
                b = stroka_before + button.ToLower() + stroka_after;
            }
            return b;
        }
        private string space_stroka(string b)
        {
            b = stroka_before + " " + stroka_after;
            return b;
        }
        public void editing()
        {
            while (stop == 0)
            {
                Console.SetCursorPosition(stolbec, stroka);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                    goup();
                else if (key.Key == ConsoleKey.DownArrow)
                    godown();
                else if (key.Key == ConsoleKey.LeftArrow)
                    goleft();
                else if (key.Key == ConsoleKey.RightArrow)
                    goright();
                else if (key.Key == ConsoleKey.Backspace)
                    delete();
                else if (key.Key == ConsoleKey.Spacebar)
                    space();
                else if (Char.IsDigit(key.KeyChar))
                    digits();
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("ВВсем пасиба всем пака)))");
                    Environment.Exit(0);
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    return;
                }
                else
                    add();
            Console.Clear();
            readfile.write();
            }
        }
    }

}
