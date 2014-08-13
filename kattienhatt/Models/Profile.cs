using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kattienhatt.Models
{
    public class Profile
    {
        public Profile()
        {
            Media = new List<Media>();
        }
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Age { get; set; }
        public string Image { get; set; }

        public virtual List<Media> Media { get; set; }
    }
}