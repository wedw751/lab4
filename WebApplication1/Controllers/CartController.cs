using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructures.Extensions;
using WebApplication1.Infrastructures;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private DataManager _dataManager;
        private ServiceManager _serviceManage;

        public CartController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManage = new ServiceManager(_dataManager);
        }
        public ViewResult Index(string returnUrl = "/Home/Index")
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            var product = _serviceManage.Preparation.GetById(Id);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", returnUrl);
        }

        public RedirectToActionResult RemoveFromCart(int Id,
                string returnUrl)
        {
            var product = _serviceManage.Preparation.GetById(Id);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", returnUrl);
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }


    }

    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
