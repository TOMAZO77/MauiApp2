namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("home", typeof(MainPage));
            Routing.RegisterRoute("dc", typeof(DCComicsPage));
            Routing.RegisterRoute("marvel", typeof(MarvelComicsPage));
            Routing.RegisterRoute("comicDetail", typeof(ComicDetailPage)); // Add this line
        }

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
