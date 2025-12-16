using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication
{
    public class CommonOutputText
    {

        private static string MainHeading
        {
            get
            {
                string heading = "Cycling Club";
                return $"{heading}\n{new string ('-', heading.Length)}";
            }
        }

        private static string RegistrationHeading
        {
            get
            {
                string heading = "Register";
                return $"{heading}\n{new string('-', heading.Length)}";
            }
        }


        private static string LoginHeading
        {
            get
            {
                string heading = "Login";
                return $"{heading}\n{new string('-', heading.Length)}";
            }
        }

        public static void WriteMainHeading()
        {
            Console.Clear();
            Console.WriteLine(MainHeading);
            Console.Write("\n\n");
        }

        public static void WriteRegistrationHeading()
        {
            Console.Clear();
            Console.WriteLine(RegistrationHeading);
            Console.Write("\n\n");
        }

        public static void WriteLoginHeading()
        {
            Console.Clear();
            Console.WriteLine(LoginHeading);
            Console.Write("\n\n");
        }

    }
}
