using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kattienhatt.Models
{
    public class Media
    {
        public int MediaId { get; set; }
        public string MediaPath { get; set; }
        public int MediaType { get; set; }
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}