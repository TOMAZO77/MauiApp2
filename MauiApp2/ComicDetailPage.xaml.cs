using System.Collections.ObjectModel;

namespace MauiApp2
{
    public partial class ComicDetailPage : ContentPage
    {
        public ObservableCollection<string> ComicPages { get; set; }

        public ComicDetailPage(string comicPath)
        {
            InitializeComponent();
            ComicPages = LoadComicPages(Path.GetDirectoryName(comicPath));
            BindingContext = this;
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

        protected override bool OnBackButtonPressed()
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                Navigation.PopAsync();
                return true;
            }
            return base.OnBackButtonPressed();
        }
    }
}
