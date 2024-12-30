namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // initializes the component, sets up the main page
        }

        private async void OnNavigateToDCComics(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("dc");
            // navigates to the DC Comics page
        }

        private async void OnNavigateToMarvelComics(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("marvel");
            // navigates to the Marvel Comics page
        }
    }
}
