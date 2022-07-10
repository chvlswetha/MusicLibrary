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

<<<<<<< HEAD
       private List<MenuItem> MenuItems;
        private ObservableCollection<Music> Songs;
        private ObservableCollection<ExtLinks> MoreLinks;

        public List<Music> Recent;
=======
        private List<MenuItem> MenuItems;
        private ObservableCollection<Music> Songs;
        private ObservableCollection<ExtLinks> MoreLinks;
        public List<Music> allRecent;

        public Stack<String> back;
        
>>>>>>> 0aa69be3cff6207d4d02715cc98e67c15f5959d6
        public MainPage()
        {
            this.InitializeComponent();

            Songs = new ObservableCollection<Music>();
            MusicManager.GetAllMusic(Songs);

<<<<<<< HEAD
=======
            allRecent = new List<Music>();

            back = new Stack<String>();

>>>>>>> 0aa69be3cff6207d4d02715cc98e67c15f5959d6
            MoreLinks = new ObservableCollection<ExtLinks>();
            MusicManager.GetMoreApps(MoreLinks);

            MusicGridView.Visibility = Visibility.Visible;
            ExtLinksGridView.Visibility = Visibility.Collapsed;
<<<<<<< HEAD
=======
            MusicMedia.Stop();
>>>>>>> 0aa69be3cff6207d4d02715cc98e67c15f5959d6

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

            BackButton.Visibility = Visibility.Collapsed;

        }

        private void MenuitemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            MenuText.Text = menuItem.category.ToString();
<<<<<<< HEAD
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

=======

            ClickedMenu(MenuText.Text);
            back.Push(MenuText.Text);
         }
>>>>>>> 0aa69be3cff6207d4d02715cc98e67c15f5959d6
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

<<<<<<< HEAD
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
=======
            var musicItem = (Music)e.ClickedItem;
            MusicMedia.Stop();

            if (musicItem.Name.ToString() == MusicGenre.HipHop.ToString() ||
                musicItem.Name.ToString() == MusicGenre.Kpop.ToString() ||
                musicItem.Name.ToString() == MusicGenre.RnB.ToString() ||
                musicItem.Name.ToString() == MusicGenre.RocknRoll.ToString())
            {
                MenuText.Text = musicItem.Name.ToString();
                back.Push(MenuText.Text);
                MusicManager.GetAllMusicByGenre(Songs, musicItem.Name.ToString());
            }
            MusicMedia.Source = new Uri(this.BaseUri, musicItem.AudioFile);

            //Add the Played Audio File to Recent Playlist Folder
            if (musicItem.AudioFile != null)
            {
                if ((allRecent.Count == 0) || (!(allRecent.Exists(x => x.Name == musicItem.Name))))
                       allRecent.Add(new Music(musicItem.Name, musicItem.ImageFile, musicItem.AudioFile));
            }

 
        }
      private void HomeButton_Click(object sender, RoutedEventArgs e)
>>>>>>> 0aa69be3cff6207d4d02715cc98e67c15f5959d6
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            MenuText.Text = "All Music";
            MusicManager.GetAllMusic(Songs);
            BackButton.Visibility = Visibility.Collapsed;
            MenuitemsListView.SelectedItem = null;
            MusicGridView.Visibility = Visibility.Visible;
            ExtLinksGridView.Visibility = Visibility.Collapsed;
            MusicMedia.Stop();
            back.Push(MenuText.Text);

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            MusicManager.GetAllMusic(Songs);
            MenuText.Text = "All Music";
            MenuitemsListView.SelectedItem = null;
        }

        private void ExtLinksGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
=======
            String backtext;
            if (back.Count != 0)
            {
                  backtext = back.Pop();
                 if (backtext == MenuText.Text && back.Count != 0)
                    backtext = back.Pop();
                ClickedMenu(backtext);
                    if (Enum.IsDefined(typeof(MusicGenre), backtext))
                    {
                        MenuText.Text = backtext;
                        MusicManager.GetAllMusicByGenre(Songs, backtext);
                    }
            }
            else
            {
                MenuText.Text = "All Music";
                MusicManager.GetAllMusic(Songs);
                BackButton.Visibility = Visibility.Collapsed;
            }
            MenuitemsListView.SelectedItem = null;
>>>>>>> 0aa69be3cff6207d4d02715cc98e67c15f5959d6


            /* MusicManager.GetAllMusic(Songs);
            MenuText.Text = "All Music";
            BackButton.Visibility = Visibility.Collapsed;
            MenuitemsListView.SelectedItem = null;
            MusicGridView.Visibility = Visibility.Visible;
            ExtLinksGridView.Visibility = Visibility.Collapsed;
            MusicMedia.Stop(); */

        }
        private void ExtLinksGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        public  void GetRecently(ObservableCollection<Music> songs)  //Getting Recent - To Do
        {
             Songs.Clear();
             allRecent.ForEach(song => songs.Add(song));
            //Recent playlist to be added
        }

        public void ClickedMenu(string menutext)
        {
            MusicGridView.Visibility = Visibility.Visible;
            ExtLinksGridView.Visibility = Visibility.Collapsed;
            MusicMedia.Stop();

            MenuText.Text = menutext;
            if (menutext == "Favorites")
                MusicManager.GetFavorites(Songs);

            if (menutext == "Genre")
                MusicManager.GetAllGenres(Songs);

            if (menutext == "Recently")
                GetRecently(Songs);

            if (menutext == "More")
            {
                MusicManager.GetMoreApps(MoreLinks);
                MusicGridView.Visibility = Visibility.Collapsed;
                ExtLinksGridView.Visibility = Visibility.Visible;
            }
            BackButton.Visibility = Visibility.Visible;
        }
    }
<<<<<<< HEAD
    }
=======
}
>>>>>>> 0aa69be3cff6207d4d02715cc98e67c15f5959d6

