﻿using System;

namespace NASAapp.DAL
{
    public class AstronomyPictureOfDayDAL
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Explanation { get; set; }
        public string HdUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Copyright { get; set; }
    }
}
