﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard2.Models {
    public class Admin {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
    }
}