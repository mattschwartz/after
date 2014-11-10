using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace After.Journal
{
    public class Entry
    {
        #region Members

        public bool Read = false;
        public string Name;
        public List<string> Updates;
        public Texture Image;

        #endregion

        public Entry()
        {
            Updates = new List<string>();
        }

        public Entry(string name, string FirstUpdate, Texture image)
        {
            Name = name;
            Updates = new List<string>() {
                FirstUpdate
            };
            Image = image;
        }

        #region Overrided methods

        public static bool operator ==(Entry lhs, Entry rhs)
        {
            return lhs.Name == rhs.Name
                && lhs.Updates.FirstOrDefault() == rhs.Updates.FirstOrDefault();
        }

        public static bool operator !=(Entry lhs, Entry rhs)
        {
            return lhs.Name != rhs.Name
                || lhs.Updates.FirstOrDefault() != rhs.Updates.FirstOrDefault();
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
