using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingIDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "File1.txt");

            FileCreator fc = new FileCreator(path);
                fc.Writing();

        }
    }
}
