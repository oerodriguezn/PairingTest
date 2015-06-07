using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class LogHelper
    {
        public static void Log(string Message, Exception ex)
        {
            Console.WriteLine(Message);
            if(ex != null)
            {
                Console.WriteLine("Exception:" + ex.Message);
                if(ex.InnerException !=null)
                    Log("Inner Exception" , ex.InnerException);
            }
        }
    }
}
