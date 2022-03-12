﻿using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class CartSpecification : Specification<Cart>
    {
        public CartSpecification(string buyerId)
        {
            Query.Include(x => x.CartItems)
                 .ThenInclude(x => x.Product.Game);
            Query.Include(x => x.CartItems)
               .ThenInclude(x => x.Product.Platform); //TODO bura patlayabilir
            Query.Include(x => x.CartItems)
                .ThenInclude(x => x.Product.Discounts); //TODO bura patlayabilir
            Query.Where(x => x.BuyerId == buyerId);
        }
    }
}
