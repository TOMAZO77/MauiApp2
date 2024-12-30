using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    [QueryProperty(nameof(ComicPath), "comicPath")]
    public partial class ComicDetailPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<string> comicPages;
        private ObservableCollection<string> filteredComicPages;

        public ObservableCollection<string> ComicPages
        {
            get => comicPages;
            set
            {
                comicPages = value;
                OnPropertyChanged(nameof(ComicPages));
            }
        }

        public ObservableCollection<string> FilteredComicPages
        {
            get => filteredComicPages;
            set
            {
                filteredComicPages = value;
                OnPropertyChanged(nameof(FilteredComicPages));
            }
        }

        public string ComicPath { get; set; }
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public ICommand SearchCommand { get; }

        public ComicDetailPage()
        {
            InitializeComponent();
            BindingContext = this;
            SearchCommand = new Command<string>(OnSearchCommand);
            // setting the data context and initializing the search command
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine("OnAppearing called");
            if (!string.IsNullOrEmpty(ComicPath))
            {
                IsBusy = true;
                ComicPages = LoadComicPages(Path.GetDirectoryName(ComicPath));
                FilteredComicPages = new ObservableCollection<string>(ComicPages);
                IsBusy = false;
                // load comic pages when the page appears
            }
        }

        private ObservableCollection<string> LoadComicPages(string folderPath)
        {
            var pages = new ObservableCollection<string>();
            try
            {
                if (Directory.Exists(folderPath))
                {
                    var imageFiles = Directory.GetFiles(folderPath, "*.jpg");
                    foreach (var file in imageFiles)
                    {
                        pages.Add(file);
                        Console.WriteLine($"Loaded comic page: {file}");
                        // add each comic page to the collection
                    }
                }
                else
                {
                    Console.WriteLine($"Directory does not exist: {folderPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading comic pages: {ex.Message}");
            }

            return pages;
        }

        private void OnSearchCommand(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                FilteredComicPages = new ObservableCollection<string>(ComicPages);
                // if search query is empty, show all comic pages
            }
            else
            {
                FilteredComicPages = new ObservableCollection<string>(
                    ComicPages.Where(p => Path.GetFileName(p).Contains(query, StringComparison.OrdinalIgnoreCase)));
                // filter comic pages based on search query
            }
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.Navigation.PopAsync();
                // go back to the previous page if possible
            }
            else
            {
                await Shell.Current.GoToAsync("//home");
                // otherwise, go back to the home page
            }
        }

        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//home");
            // navigate to the home page
        }
    }
}
