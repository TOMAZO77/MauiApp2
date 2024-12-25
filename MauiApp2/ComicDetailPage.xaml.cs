using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    [QueryProperty(nameof(ComicPath), "comicPath")]
    public partial class ComicDetailPage : ContentPage
    {
        public ObservableCollection<string> ComicPages { get; set; }
        public string ComicPath { get; set; }

        public ComicDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!string.IsNullOrEmpty(ComicPath))
            {
                ComicPages = LoadComicPages(Path.GetDirectoryName(ComicPath));
                BindingContext = this;
            }
        }

        private ObservableCollection<string> LoadComicPages(string folderPath)
        {
            var pages = new ObservableCollection<string>();
            var imageFiles = Directory.GetFiles(folderPath, "*.jpg");

            foreach (var file in imageFiles)
            {
                pages.Add(file);
            }

            return pages;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                await Shell.Current.GoToAsync("//home");
            }
        }
    }
}
