using ClubMemebershipApplication.Data;
using ClubMemebershipApplication.FieldValidators;
using ClubMemebershipApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication.Views
{
    public class UserLoginView : IViews
    {
        ILogin _loginUser = null;
        public IFieldValidator FieldValidator => null;

        public UserLoginView(ILogin login)
        {
            _loginUser = login;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address");
            string emailAddress = Console.ReadLine();

            Console.WriteLine("Please enter your Password");
            string password = Console.ReadLine();

            User user = _loginUser.login(emailAddress, password);

            if (user != null)
            {
                WelcomeView welcomeView = new WelcomeView(user);
                welcomeView.RunView();
            }
            else
            {
                CommonOutputFormat.ChangeFontColor(FontFormat.Danger);
                Console.WriteLine("The credentials that you entered do not match out records");
                CommonOutputFormat.ChangeFontColor(FontFormat.Default);
                Console.ReadKey();

            }

        }
    }
}
