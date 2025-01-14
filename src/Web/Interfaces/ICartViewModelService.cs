﻿using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces
{
    public interface ICartViewModelService
    {
        Task<CartViewModel> GetCartViewModelAsync();
        Task<int> GetCartItemsCountAsync();
        Task<CartViewModel> AddToCartAsync(int productId, int quantity);
        Task<CartViewModel> UpdateCartAsync(Dictionary<int, int> quantities);
        Task<Cart> GetOrCreateCartAsync();
        Task<string> GetOrCreateBuyerIdAsync();
        Task<OrderCompleteViewModel> CompleteCheckoutAsync(string email);
    }
}