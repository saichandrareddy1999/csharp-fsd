using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace introduction
{
    public class ExceptionHandling
    {
        static void Main()
        {
            StreamReader streamReader = new StreamReader(@"C:\Users\dell\OneDrive\Desktop\data.txt");
            Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();

        }
    }
}
