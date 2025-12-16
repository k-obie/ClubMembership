using ClubMemebershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication.Views
{
    public class MainView : IViews
    {
        public IFieldValidator FieldValidator => null;

        IViews _registerView = null;
        IViews _loginView = null;
        public MainView(IViews registerView, IViews loginView)
        {
            _loginView = loginView;
            _registerView = registerView;
        }


        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("Please press 'l' to login or if you are not yet registered please press 'r'");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.R)
            {
                RunRegistrationView();

            }else if (key == ConsoleKey.L)
            {
                RunLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("GoodBye");
                Console.ReadKey();
            }

        }

        private void RunRegistrationView()
        {
            _registerView.RunView();
        }

        private void RunLoginView()
        {
            _loginView.RunView();
        }
    }
}
