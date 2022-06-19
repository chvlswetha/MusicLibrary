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
        public static void GetAllMusicByGenre(ObservableCollection<Music> songs, String genre)  //Datarefresh everytime with observablecollection
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

        public static void GetFavorites(ObservableCollection<Music> songs)  //Getting Favorites - To Do
        {
            songs.Clear();
            //Favorites to be added
        }

        public static void GetRecently(ObservableCollection<Music> songs)  //Getting Recent - To Do
        {
            songs.Clear();
            //Recent playlist to be added
        }


        public static void GetMoreApps(ObservableCollection<Music> songs)  //Getting All songs - In Progress
        {
            var MoreApps = new List<Music>();
            MoreApps.Add(new Music("googleplay", MusicCategory.More));
            MoreApps.Add(new Music("pandora", MusicCategory.More));
            MoreApps.Add(new Music("spotify", MusicCategory.More));
            MoreApps.Add(new Music("youtube", MusicCategory.More));
            songs.Clear();
            MoreApps.ForEach(song => songs.Add(song));
        }

    }
}
