using ClubMemebershipApplication.FieldValidators;
using ClubMemebershipApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication.Views
{
    public class WelcomeView : IViews
    {
        User _user = null;

        public WelcomeView(User user)
        {
            _user = user;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            CommonOutputFormat.ChangeFontColor(FontFormat.Sucess);
            Console.WriteLine($"Hi {_user.FirstName}!!\nWelcome to the Cycling Club!!");
            CommonOutputFormat.ChangeFontColor(FontFormat.Default);
            Console.ReadKey();

        }
    }
}
