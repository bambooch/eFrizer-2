﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class ReviewSearchRequest
    {
        public int HairSalonId { get; set; }
        
        public int ClientId { get; set; }

        //public string Text { get; set; }
        //public int? StarRating { get; set; }
    }
}
