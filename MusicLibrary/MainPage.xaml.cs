using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

       private List<MenuItem> MenuItems;
        public MainPage()
        {
            this.InitializeComponent();
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

        }

        private void MusicGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
