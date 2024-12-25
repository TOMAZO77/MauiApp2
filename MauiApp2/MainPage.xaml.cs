namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToDCComics(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("dc");
        }

        private async void OnNavigateToMarvelComics(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("marvel");
        }
    }
}
