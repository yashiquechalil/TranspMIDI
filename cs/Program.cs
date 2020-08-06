using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

          static void Main(string[] args)
        {
            xformidi xformidi1 = new xformidi(args[0]);
            Console.WriteLine("{0}", xformidi1.ToString());

            string[] fnames = xformidi1.GetSourceFileNames();

            int filecount = 0;
            foreach(var f in fnames)
            {
                Console.WriteLine("   {0} - {1}", filecount++, f);
                var task = call_cmd( f, args[1], args[2]);
                task.Wait(1000);
            }

        }


     public static async Task<string> call_cmd(string ifile, string val1, string val2)
        {
            string res = "call cmd ok";
            Console.WriteLine("file = {0}, Argument = {1}, Argument2 = {2}",ifile, val1, val2 );

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "./t.sh";
            startInfo.Arguments = ifile + " " + val1 + " " + val2;
            process.StartInfo = startInfo;
            process.Start();

            return res;
        }


    }
}
