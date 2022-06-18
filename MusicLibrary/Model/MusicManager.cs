using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public static class MusicManager
    {
        // getMusic method will give you back a List of all instances songs 
        private static List<Music> getMusic()
        {
            var songs = new List<Music>();
            songs.Add(new Music("Holizna", MusicGenre.HipHop));
            songs.Add(new Music("Makaih", MusicGenre.HipHop));
            songs.Add(new Music("IceCream", MusicGenre.Kpop));
            songs.Add(new Music("YetToCome", MusicGenre.Kpop));
            songs.Add(new Music("Better", MusicGenre.RnB));
            songs.Add(new Music("Vibin", MusicGenre.RnB));
            songs.Add(new Music("Kinks", MusicGenre.RocknRoll));
            songs.Add(new Music("Rolling", MusicGenre.RocknRoll));

            return songs;
        }

        public static void GetAllMusic(ObservableCollection<Music> songs)
        {
            var allSongs = getMusic();
            songs.Clear();
            allSongs.ForEach(song => songs.Add(song));
        }

        private static List<Music> getGenres()
        {
            var genres = new List<Music>();
            genres.Add(new Music("HipHop", MusicCategory.Genre));
            genres.Add(new Music("Kpop", MusicCategory.Genre));
            genres.Add(new Music("Rnb", MusicCategory.Genre));
            genres.Add(new Music("RocknRoll", MusicCategory.Genre));

            return genres;
        }

        public static void GetAllGenres(ObservableCollection<Music> genres)
        {
            var allGenres = getGenres();
            genres.Clear();
            allGenres.ForEach(genre => genres.Add(genres));
        }


        public static void GetAllMusicByGenre(ObservableCollection<Music> songs, MusicGenre genre)
        {
            var allGenres = getGenres();
            var filteredGenres = allGenres.Where(
                song => song.Genre == genre).ToList();

            songs.Clear();
            filteredSongs.ForEach(song => songs.Add(song));

        }
           

    }
}
