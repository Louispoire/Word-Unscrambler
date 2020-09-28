using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {

        public string[] read(string filename)
        {
            string[] file = File.ReadAllLines(filename);
            return file;
        }

    }
}
