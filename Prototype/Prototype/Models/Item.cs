using System;

namespace Prototype.Models
{
    public class Item : Realms.RealmObject
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public DateTimeOffset InTime { get; set; }
        public DateTimeOffset OutTime { get; set; }
    }
}