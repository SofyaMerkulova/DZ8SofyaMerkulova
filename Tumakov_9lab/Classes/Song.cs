using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_9lab.Classes
{
    internal class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song Early { get; set; }
        public Song(string name, string author)
        {
            this.Name = name;
            this.Author = author;
            this.Early = null;
        }
        public Song(string name, string author, Song early)
        {
            this.Name = name;
            this.Author = author;
            this.Early = early;
        }
        public Song()
        {
            this.Name = string.Empty;
            this.Author = string.Empty;
            this.Early = null;
        }
        public string Title()
        {
            return $"Название: {Name}, Исполнитель: {Author}";
        }
        public override bool Equals(object d)
        {
            if (d is Song otherSong)
            {
                return this.Name == otherSong.Name && this.Author == otherSong.Author;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Author.GetHashCode();
        }
    }
}
