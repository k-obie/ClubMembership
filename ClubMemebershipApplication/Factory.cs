using ClubMemebershipApplication.Data;
using ClubMemebershipApplication.FieldValidators;
using ClubMemebershipApplication.Views;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication
{
    public class Factory
    {
        public static IViews GetMainViewObject()
        {
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IFieldValidator userRegistrationValidator = new UserRegistrationValidator(register);
            userRegistrationValidator.InitilialiseValidatorDelegates();

            IViews registerView = new UserRegistrationView(register, userRegistrationValidator);
            IViews loginView = new UserLoginView(login);
            IViews mainView = new MainView(registerView, loginView);

            return mainView; 
        }
    }
}
