﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05._ShopHierarchy
{
    public class Review
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

    }
}
