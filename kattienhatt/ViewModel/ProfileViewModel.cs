using kattienhatt.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace kattienhatt.ViewModel
{
    public class ProfileViewModel
    {
        public Profile Profile { get; set; }

        public Media Media { get; set; }

        public string GetYouTubeVideoId(string url)
        {

            string urlregex = @"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)";

            var regex = new Regex(urlregex);

            var match = regex.Match(url);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return url;

        }

        public IEnumerable<SelectListItem> MediaTypeSelectList
        {
            get
            {
                var selectlist = new List<SelectListItem>
                {
                    new SelectListItem{ Text = "Bild", Value = "1"},
                    new SelectListItem { Text = "Youtube", Value = "2"}
                };

                return selectlist;
            }
        }
    }
}