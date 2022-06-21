﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    class ExtLinks
    {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string ExtURL { get; set; }

        public ExtLinks(String name)
        {
            Name = name;
            ImageFile = $"/Assets/Images/More/{name}.png";
            ExtURL = $"https://www.{name}.com";
         }
    }
}
