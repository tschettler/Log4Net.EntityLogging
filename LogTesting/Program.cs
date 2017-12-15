using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogTesting
{
    class Program
    {
        private static ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            try
            {
                throw new Exception("A random exception was thrown");
            }
            catch(Exception ex)
            {
                logger.Error("An exception occurred", ex);
            }
        }
    }
}
