﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmazonSearch.Models
{
    public class ItemModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public string Price { get; set; }
    }
}