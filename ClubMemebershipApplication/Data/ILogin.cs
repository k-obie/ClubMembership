using ClubMemebershipApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication.Data
{
    public interface ILogin
    {
        User login(string emailAddress, string password);
    }
}
