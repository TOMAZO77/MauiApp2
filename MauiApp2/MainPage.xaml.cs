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

        private async void OnComicSelected(object sender, EventArgs e)
        {
            // Assuming you have a method to handle comic selection
            string comicPath = "path_to_comic"; // Replace with actual comic path
            await Shell.Current.GoToAsync($"comicDetail?comicPath={comicPath}");
        }
    }
}
