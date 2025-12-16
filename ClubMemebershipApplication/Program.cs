using ClubMemebershipApplication.Model;
using ClubMemebershipApplication.Views;

namespace ClubMemebershipApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IViews mainView = Factory.GetMainViewObject();
            mainView.RunView();

            Console.ReadKey();
        }
    }
}
