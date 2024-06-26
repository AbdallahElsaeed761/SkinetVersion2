﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductSpecparameters
    {
        private const int MaxPageSize  = 50;
        public  int PageIndex { get; set; } = 1;

        public  int _PageSize  = 6;
        public int PageSize {
            get => _PageSize;
            set => _PageSize = (value>MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Sort { get; set; }



    }
}
