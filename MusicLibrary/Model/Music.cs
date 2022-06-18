﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }

        public Music(string name, MusicCategory category)
        {
            Name = name;
            Category = category;

              ImageFile = $"/Assets/Images/{category}/{name}.png";
              if (Category !=  MusicCategory.More)
              AudioFile = $"/Assets/Audio/{category}/{name}.wav";
       }
        public Music(string name,  MusicGenre genre)
        {
              Name = name;
              Category = MusicCategory.Genre;
             ImageFile = $"/Assets/Images/{Category}/{genre}/{name}.png";
             AudioFile = $"/Assets/Audio/{Category}/{genre}/{name}.wav";
         }
     }
}