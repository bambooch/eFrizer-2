﻿using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Service
    {
        public Service()
        {
            HairSalonServices = new HashSet<HairSalonService>();
        }

        public int ServicesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<HairSalonService> HairSalonServices { get; set; }
    }
}
