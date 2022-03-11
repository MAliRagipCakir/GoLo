﻿using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ProductNewReleaseSpecification : Specification<Product>
    {
        public ProductNewReleaseSpecification()
        {
            Query.Include(x => x.Game);
            Query.Include(x => x.Discounts);
            Query.Include(x => x.Platform);
            Query.Where(x => x.Game.ReleaseDate >= DateTime.Now.AddMonths(-3) && x.Game.ReleaseDate <= DateTime.Now).OrderByDescending(x => x.Game.ReleaseDate);
            Query.Take(10);
        }
    }
}