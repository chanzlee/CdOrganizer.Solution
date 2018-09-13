using System;
using System.Collections.Generic;

namespace CdOrganizer.Models
{
    public class Artist
    {
        private string _name;
        private static List<Artist> _instances = new List<Artist> {};
        private int _id;
        private List<Cd> _cds;

        public Artist(string artistName)
        {
            _name = artistName;
            _instances.Add(this);
            _id = _instances.Count;
            _cds = new List<Cd>{};
        }

        public string GetName()
        {
            return _name;
        }
        public int GetId()
        {
            return _id;
        }
        public static List<Artist> GetAll()
        {
            return _instances;
        }
        public List<Cd> GetCds()
        {
            return _cds;
        }
        public void AddCd(Cd newCd)
        {
            _cds.Add(newCd);
        }

        public static Artist Find(int searchId)
        {
            return _instances[searchId -1];
        }

    }

    public class Cd
    {
        private string _title;
        private int _id;
        private static List<Cd> _instances = new List<Cd> {};
        public Cd (string newTitle)
        {
            _title = newTitle;
            _instances.Add(this);
            _id = _instances.Count;
        }

        public string GetTitle()
        {
            return _title;
        }
        public int GetId()
        {
            return _id;
        }
        public static List<Cd> GetAll()
        {
          return _instances;
        }
        public void Save()
        {
          _instances.Add(this);
        }
        public static void ClearAll()
        {
          _instances.Clear();
        }

        public static Cd Find(int searchId)
        {
            return _instances[searchId -1];
        }

    }
}
