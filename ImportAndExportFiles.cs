using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnalysisHypotheses
{
    class ImportAndExportFiles
    {
        //зчитування CSV i TXT
        public static void ImportFile(FileStream fs)
        {
            var sr = new StreamReader(fs);
            string str = "", token = "";

            while(!sr.EndOfStream)
            {
                str = sr.ReadLine();
                token = "";
                str = str.Trim();

                if (str[0] == '"')
                {
                    var i = 2;
                    while (str[i] != ')')
                    {
                        token += str[i];
                        i++;
                    }
                    i+=3;

                    var a = "";
                    var b = "";
                    var j = 0;
                    
                    while(token[j]!=';')
                    {
                        a += token[j];
                        j++;
                    }
                    j++;
                    while (j < token.Length)
                    {
                        b += token[j];
                        j++;
                    }

                    token = "";
                    while(i < str.Length)
                    {
                        token += str[i];
                        i++;
                    }

                    try
                    {
                        Row.AddToRow(new IntervalVariant(Convert.ToDouble(a), Convert.ToDouble(b), Convert.ToInt32(token)));
                    }
                    catch(Exception)
                    {
                        Row.ClearRow();
                        MessageBox.Show("Некоректні дані у файлі: (" + a + ";" + b + ") " + token);
                    }

                }

                else
                {
                    var i = 0;
                    while(str[i] != ';')
                    {
                        token += str[i];
                        i++;
                    }
                    var x = token;
                    token = "";
                    i++;

                    while (i < str.Length)
                    {
                        token += str[i];
                        i++;
                    }
                    
                    try
                    {
                        Row.AddToRow(new IntervalVariant(Convert.ToDouble(x), Convert.ToDouble(x), Convert.ToInt32(token)));
                    }
                    catch (Exception)
                    {
                        Row.ClearRow();
                        MessageBox.Show("Некоректні дані у файлі: " + x + " " + token);
                    }

                }
            }
            sr.Close();
        }

        public static void ExportFile(string filename, int ext)
        {          
            switch(ext)
            {
                case 1:
                    File.Copy(Directory.GetCurrentDirectory() + "/tmp/textFile.txt", filename);
                    break;
                case 2:
                    File.Copy(Directory.GetCurrentDirectory() + "/tmp/htmlFile.html", filename);
                    break;
                case 3:
                    File.Copy(Directory.GetCurrentDirectory() + "/tmp/textFile.txt", filename);
                    break;
                default:
                    break;
            }
        }

        public static void WriteText(string str)
        {
            var sw = new StreamWriter(Directory.GetCurrentDirectory() + "/tmp/textFile.txt", true, Encoding.UTF8);
            sw.WriteLine(str);
            sw.Close();
        }

        public static void WriteHTML(string str)
        {
            var sw = new StreamWriter(Directory.GetCurrentDirectory() + "/tmp/htmlFile.html", true);
            sw.WriteLine(str);
            sw.Close();
        }

        public static void Clear()
        {
            var sw1 = new StreamWriter(Directory.GetCurrentDirectory() + "/tmp/textFile.txt", false, Encoding.UTF8);
            sw1.Close();
            var sw2 = new StreamWriter(Directory.GetCurrentDirectory() + "/tmp/htmlFile.html", false);
            sw2.Close();
        }
    }
}