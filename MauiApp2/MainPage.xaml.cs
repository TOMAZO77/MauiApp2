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
            await Navigation.PushAsync(new DCComicsPage());
        }

        private async void OnMarvelComicsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MarvelComicsPage());
        }
    }
}
