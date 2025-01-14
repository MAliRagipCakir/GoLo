﻿using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        public decimal ProductUnitPrice { get; set; }
        public bool IsAvailable { get; set; }
        public int UnitInStocks { get; set; }
        public int PlatformId { get; set; }
        public int GameId { get; set; }
        public bool IsEditorsChoice { get; set; } = false;
        public Game Game { get; set; }
        public Platform Platform { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<Key> Keys { get; set; }

        public int GetDiscountRate()
        {
            return Discounts.FirstOrDefault(x => x.IsValid) == null ? 0 : Discounts.FirstOrDefault(x => x.IsValid).DiscountRate;
        }
        public int GetUnitStocks()
        {
            return Keys.Where(x => x.Status).ToList().Count();
        }
    }
}
