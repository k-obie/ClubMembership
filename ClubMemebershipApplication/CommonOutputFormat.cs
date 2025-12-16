using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication
{
    public enum FontFormat
    {
        Default,
        Danger,
        Sucess
    }
    public static class CommonOutputFormat
    {
        public static void ChangeFontColor(FontFormat fontFormat)
        {
            if (fontFormat == FontFormat.Danger)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (fontFormat == FontFormat.Sucess)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }
        }
    }
}
