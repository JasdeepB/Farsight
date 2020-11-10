using System.Collections.Generic;

namespace Farsight.Deserializable_Objects.Perks
{
    public class AllRunes
    {
        public int id { get; set; }
        public string key { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public List<Slots> slots { get; set; }

        public class Slots
        {
            public List<Runes> runes { get; set; }
        }

        public class Runes
        {
            public int id { get; set; }
            public string key { get; set; }
            public string icon { get; set; }
            public string name { get; set; }
            public string shortDesc { get; set; }
            public string longDesc { get; set; }
        }
    }
}
