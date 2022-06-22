using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    class MusicManager
    {
        private static List<Music> getMusic()  //Adding all songs -Home page -Done
        {
            var songs = new List<Music>();
            songs.Add(new Music("Holizna", MusicGenre.HipHop));
            songs.Add(new Music("Makaih", MusicGenre.HipHop));
            songs.Add(new Music("IceCream", MusicGenre.Kpop));
            songs.Add(new Music("YetToCome", MusicGenre.Kpop));
            songs.Add(new Music("Better", MusicGenre.RnB));
            songs.Add(new Music("Vibin", MusicGenre.RnB));
            songs.Add(new Music("Kinks", MusicGenre.RocknRoll));
            songs.Add(new Music("RollingStone", MusicGenre.RocknRoll));

            return songs;
        }
        public static void GetAllMusic(ObservableCollection<Music> songs)  //Getting All songs
        {
            var allSongs = getMusic();
            songs.Clear();
            allSongs.ForEach(song => songs.Add(song));
        }

        public static List<Music> getGenre() //Adding all Genres under Category "genre"
        {
            List<Music> genres = new List<Music>();
            genres.Add(new Music("HipHop", MusicCategory.Genre));
            genres.Add(new Music("Kpop", MusicCategory.Genre));
            genres.Add(new Music("RnB", MusicCategory.Genre));
            genres.Add(new Music("RocknRoll", MusicCategory.Genre));

            return genres;
        }

        public static void GetAllGenres(ObservableCollection<Music> genres) //Getting all Genres
        {
            var allgenres = getGenre();
            genres.Clear();
            allgenres.ForEach(genre => genres.Add(genre));
        }

        //Getting all music by Genre - Done
        public static void GetAllMusicByGenre(ObservableCollection<Music> songs, string genre)  //Datarefresh everytime with observablecollection
        {
            var allsongs = getMusic();
            //where (var sound in allsounds) filter by category

            var filteredsongs = allsongs.Where(
                song => song.Genre.ToString() == genre).ToList(); //LINQ statement

            songs.Clear();
            /* foreach(var sound in filteredsounds)
                  sounds.Add(sound);*/
            filteredsongs.ForEach(song => songs.Add(song));  //LAMBDA statement

        }
             
     
        //Getting Favorites 
        public static void GetFavorites(ObservableCollection<Music> songs)  //Getting favorites
        {
            var allFavorites = new List<Music>();
            allFavorites.Add(new Music("Kinks", MusicCategory.Favorites));
            allFavorites.Add(new Music("Makaih", MusicCategory.Favorites));
            songs.Clear();
            allFavorites.ForEach(song => songs.Add(song));
        }
       public static void GetMoreApps(ObservableCollection<ExtLinks> links)  //Getting External links-Done
        {
            var MoreApps = new List<ExtLinks>();
            MoreApps.Add(new ExtLinks("Pandora"));
            MoreApps.Add(new ExtLinks("Spotify"));
            MoreApps.Add(new ExtLinks("Youtube"));
            links.Clear();
            MoreApps.ForEach(link => links.Add(link));

        }

    }
}
