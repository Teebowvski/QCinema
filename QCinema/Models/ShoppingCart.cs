﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QCinema.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QCinema.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Movie movie, double amount)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Movie.Name == movie.Name && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Movie.Name == movie.Name && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = (int)shoppingCartItem.Amount;
                }

            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);

            }
            _context.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Movie).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Movie.Price * c.Amount).Sum();
            return total;
        }

    }
}
