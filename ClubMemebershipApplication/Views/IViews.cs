using ClubMemebershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication.Views
{
    public interface IViews
    {

        void RunView();
        IFieldValidator FieldValidator { get;  }

    }
}
