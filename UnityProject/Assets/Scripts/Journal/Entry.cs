using UnityEngine;

namespace After.Journal
{
    public class Entry
    {
        public string Name;
        public string Description;
        public Texture Image;

        public Entry()
        {
        }

        public Entry(string name, string description, Texture image)
        {
            Name = name;
            Description = description;
            Image = image;
        }
    }
}
