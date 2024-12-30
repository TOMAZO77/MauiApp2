namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // register routes for navigation
            Routing.RegisterRoute("home", typeof(MainPage));
            Routing.RegisterRoute("dc", typeof(DCComicsPage));
            Routing.RegisterRoute("marvel", typeof(MarvelComicsPage));
            Routing.RegisterRoute("comicDetail", typeof(ComicDetailPage));
        }

        // handle back button press
        protected override bool OnBackButtonPressed()
        {
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                Shell.Current.Navigation.PopAsync();
                return true;
            }
            else
            {
                Shell.Current.GoToAsync("//home");
                return true;
            }
        }
    }
}
