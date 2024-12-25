namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnDCComicsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("dc");
        }

        private async void OnMarvelComicsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("marvel");
        }
    }
}
