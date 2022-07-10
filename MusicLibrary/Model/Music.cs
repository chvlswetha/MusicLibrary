using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Documents;

namespace MusicLibrary.Model
{
    public enum MusicCategory
    {
        Genre,
        Favorites,
        Recently,
        More
    }

    public enum MusicGenre
    {
        HipHop,
        Kpop,
        RnB,
        RocknRoll
    }
    public class Music
    {
        public string Name { get; set; }
        public MusicCategory Category { get; set; }
        public MusicGenre Genre { get; set; }
        public string AudioFile { get; set; }


        public string ImageFile { get; set; }

        public Music(string name, MusicCategory category)
        {
            Name = name;
            Category = category;
<<<<<<< HEAD
             if (Category ==  MusicCategory.Genre)
             ImageFile = $"/Assets/Images/{Category}/{name}.png";
            
           else
            {
              ImageFile = $"/Assets/Images/{category}/{name}.png";
              AudioFile = $"/Assets/Audio/{category}/{name}.wav";
            }
            
       }
        public Music(string name, MusicGenre genre)
        {
                Name = name;
                Category = MusicCategory.Genre;
                Genre= genre;
                ImageFile = $"/Assets/Images/{Category}/{genre}/{name}.png";
                AudioFile = $"/Assets/Audio/{Category}/{genre}/{name}.wav";
        }

=======
            if (Category == MusicCategory.Genre)
            {
                ImageFile = $"/Assets/Images/{Category}/{name}.png";
            }
            else
            {
                ImageFile = $"/Assets/Images/{category}/{name}.png";
                if (Category != MusicCategory.More)
                    AudioFile = $"/Assets/Audio/{category}/{name}.wav";
            }
        }
        public Music(string name, MusicGenre genre)
        {
            Name = name;
            Category = MusicCategory.Genre;
            Genre = genre;
            ImageFile = $"/Assets/Images/{Category}/{genre}/{name}.png";
            AudioFile = $"/Assets/Audio/{Category}/{genre}/{name}.wav";

        }

        public Music(string name,string imagefile, string audiofile)
        {
            Name = name;
            Category = MusicCategory.Recently;
            ImageFile = imagefile;
            AudioFile = audiofile;

        }
>>>>>>> 0aa69be3cff6207d4d02715cc98e67c15f5959d6
    }
}
