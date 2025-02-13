﻿using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class HairSalon
    {
        public HairSalon()
        {
            HairDressers = new HashSet<HairDresser>();
            HairSalonHairSalonTypes = new HashSet<HairSalonHairSalonType>();
            HairSalonPictures = new HashSet<HairSalonPicture>();
            HairSalonServices = new HashSet<HairSalonService>();
            Reviews = new HashSet<Review>();
        }

        public int HairSalonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<HairDresser> HairDressers { get; set; }
        public virtual ICollection<HairSalonHairSalonType> HairSalonHairSalonTypes { get; set; }
        public virtual ICollection<HairSalonPicture> HairSalonPictures { get; set; }
        public virtual ICollection<HairSalonService> HairSalonServices { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TextReview> TextReviews { get; set; }
    }
}


