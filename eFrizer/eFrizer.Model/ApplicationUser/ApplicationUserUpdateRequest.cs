﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class ApplicationUserUpdateRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
