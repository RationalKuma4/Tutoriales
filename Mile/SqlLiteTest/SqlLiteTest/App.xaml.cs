using SqlLiteTest.Repositories;
using Xamarin.Forms;

namespace SqlLiteTest
{
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("people.db3");
        public static PersonRepository PersonRepository;
        public App()
        {
            InitializeComponent();

            PersonRepository = new PersonRepository(dbPath);
            MainPage = new MainPage
            {
                Text = dbPath
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
