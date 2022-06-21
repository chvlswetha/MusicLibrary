using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MusicLibrary.Model;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

       private List<MenuItem> MenuItems;
        private ObservableCollection<Music> Songs;
        private ObservableCollection<ExtLinks> MoreLinks;

        public List<Music> Recent;
        public MainPage()
        {
            this.InitializeComponent();

            Songs = new ObservableCollection<Music>();
            MusicManager.GetAllMusic(Songs);

            MoreLinks = new ObservableCollection<ExtLinks>();
            MusicManager.GetMoreApps(MoreLinks);

            MusicGridView.Visibility = Visibility.Visible;
            ExtLinksGridView.Visibility = Visibility.Collapsed;

            MenuItems = new List<MenuItem>();

            MenuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Favorites.png",
                category = MusicCategory.Favorites
            });
            MenuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Genres.png",
                category = MusicCategory.Genre
            });
            MenuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Recently.png",
                category = MusicCategory.Recently
            });
            MenuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/More.png",
                category = MusicCategory.More
            });
        }

        private void MenuitemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            MenuText.Text = menuItem.category.ToString();
            MusicGridView.Visibility = Visibility.Visible;
            ExtLinksGridView.Visibility = Visibility.Collapsed;

            if  (MenuText.Text == "Favorites")
                MusicManager.GetFavorites(Songs);

            if (MenuText.Text == "Genre")
                MusicManager.GetAllGenres(Songs);

            if (MenuText.Text == "Recently Played")
                MusicManager.GetRecently(Songs);

            if (MenuText.Text == "More") {
                MusicManager.GetMoreApps(MoreLinks);
                MusicGridView.Visibility = Visibility.Collapsed;
                ExtLinksGridView.Visibility = Visibility.Visible;
            }
        }

        private void MusicGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var musicItem = (Music)e.ClickedItem;
            if (musicItem.Name.ToString() == MusicGenre.HipHop.ToString() ||
                musicItem.Name.ToString() == MusicGenre.Kpop.ToString() ||
                musicItem.Name.ToString() == MusicGenre.RnB.ToString() ||
                musicItem.Name.ToString() == MusicGenre.RocknRoll.ToString())
            {
                MusicManager.GetAllMusicByGenre(Songs, musicItem.Name.ToString());
            }
            MusicMedia.Source = new Uri(this.BaseUri, musicItem.AudioFile);

            //Adding song to Recent Playlist
            if (musicItem.AudioFile != string.Empty)
            {

                var sourceFile = $"{musicItem.ImageFile}";

                var destFile = $"/Assets/Images/Recently/{musicItem.Name}.png";
                //System.IO.File.Copy(sourceFile, destFile, true);

                //Recent.Add(new Music(musicItem.Name, MusicCategory.Recently));
            }
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MusicManager.GetAllMusic(Songs);
            MenuText.Text = "All Music";
            MenuitemsListView.SelectedItem = null;
        }

        private void ExtLinksGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
    }

