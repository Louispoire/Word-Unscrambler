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

            string[] file;
            try
            {
                file = File.ReadAllLines(filename);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return file;

        }

    }
}
