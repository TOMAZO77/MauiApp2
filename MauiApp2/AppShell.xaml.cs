namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("main", typeof(MainPage));
            Routing.RegisterRoute("dc", typeof(DCComicsPage));
            Routing.RegisterRoute("marvel", typeof(MarvelComicsPage));
        }

        protected override bool OnBackButtonPressed()
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                Navigation.PopAsync();
                return true;
            }
            else
            {
                Shell.Current.GoToAsync("//main");
                return true;
            }
        }
    }
}
