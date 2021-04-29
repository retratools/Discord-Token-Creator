using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Console = Colorful.Console;
using System.Threading;

namespace Discord_Token_Creator
{
    public class Settings
    {
        public static void AutoLoadSettings()
        {
            Console.Clear();
            if (File.Exists("Settings.retra"))
            {
                string str = File.ReadAllText("Settings.retra");
                try
                {
                    Variables.TwoCapKey = Functions.LR(str, "[2capkey]-", "-[2capkey]").FirstOrDefault();
                }
                catch
                {
                    Console.WriteLine("Error Parsing Configuration...");
                    Thread.Sleep(200);
                    File.Delete("Settings.retra");
                    AutoLoadSettings();
                }

            }
            else
            {
                Console.Write("2cap Key: ");
                Variables.TwoCapKey = Console.ReadLine();
                File.AppendAllText("Settings.retra", "[2capkey]-" + Variables.TwoCapKey + "-[2capkey]" + Environment.NewLine);


            }
        }
    }
}