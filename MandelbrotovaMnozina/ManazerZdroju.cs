using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace MandelbrotovaMnozina
{
    public static class ManazerZdroju
    {
        public static string NacistZdroj(string jmeno)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string cesta = assembly.GetManifestResourceNames().Single(x => x.EndsWith(jmeno));
            Stream stream = assembly.GetManifestResourceStream(cesta);
            StreamReader reader = new StreamReader(stream);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }
    }
}
