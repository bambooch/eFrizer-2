﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public partial class HairSalonHairSalonTypeInsertRequest : HairSalonTypeInsertRequest
    {
        public int HairSalonId { get; set; }
        public int HairSalonTypeId { get; set; }
    }
}
