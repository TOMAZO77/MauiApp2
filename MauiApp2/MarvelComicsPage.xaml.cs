using System.Collections.ObjectModel;

namespace MauiApp2
{
    public partial class MarvelComicsPage : ContentPage
    {
        public ObservableCollection<string> ComicCovers { get; set; }

        public MarvelComicsPage()
        {
            InitializeComponent();
            ComicCovers = LoadComicCovers(@"C:\Users\Xemen\Downloads\Comics\Marvel");
            BindingContext = this;
            // set the data context and load comic covers
        }

        private ObservableCollection<string> LoadComicCovers(string folderPath)
        {
            var covers = new ObservableCollection<string>();
            var directories = Directory.GetDirectories(folderPath);

            foreach (var dir in directories)
            {
                var cover = Directory.GetFiles(dir, "*.jpg").FirstOrDefault();
                if (cover != null)
                {
                    covers.Add(cover);
                    // add comic cover to the collection
                }
            }

            return covers;
        }

        private async void OnComicSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedComicPath = e.CurrentSelection.FirstOrDefault() as string;
            if (selectedComicPath != null)
            {
                // Deselect the comic to allow reopening the same comic
                ((CollectionView)sender).SelectedItem = null;
                await Shell.Current.GoToAsync($"comicDetail?comicPath={selectedComicPath}");
                // navigate to comic detail page
            }
        }
    }
}
