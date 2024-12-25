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

        private async void OnComicSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedComicPath = e.CurrentSelection.FirstOrDefault() as string;
            if (selectedComicPath != null)
            {
                await Shell.Current.GoToAsync($"comicDetail?comicPath={selectedComicPath}");
            }
        }
    }
}
