using AutoMapper;
using ECommerce.DTOs.Cart;
using ECommerce.DTOs.Checkout;
using ECommerce.DTOs.Order;
using ECommerce.DTOs.Product;
using ECommerce.Models.Entities;
using ECommerce.Services.Interfaces;
using ECommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public CartController(IProductService productService,IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
            _orderService = orderService;
        }
        public ActionResult Index()
        {
            var cart = Session["Cart"] as List<CartItemDTO> ?? new List<CartItemDTO>();
            return View(cart);
        }
        private List<CartItemDTO> GetCart()
        {
            var cart = Session["Cart"] as List<CartItemDTO>;
            if (cart == null)
            {
                cart = new List<CartItemDTO>();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int  productId)
        {
            var product = _productService.GetById(productId);
            if (product == null) return HttpNotFound();

            var cart = Session["Cart"] as List<CartItemDTO> ?? new List<CartItemDTO>();
            var existing = cart.Find(x => x.ProductId == productId);

            if (existing != null)
                existing.Quantity++;
            else
                cart.Add(new CartItemDTO
                {
                    ProductId = productId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });

            Session["Cart"] = cart;
            return RedirectToAction("ViewCart");
        }

        public ActionResult Remove(int id)
        {
            var cart = Session["Cart"] as List<CartItemDTO>;
            var item = cart?.Find(x => x.ProductId == id);
            if (item != null) cart.Remove(item);
            Session["Cart"] = cart;
            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int productId, string action)
        {
            var cart = Session["Cart"] as List<CartItemDTO>;
            var item = cart.FirstOrDefault(p => p.ProductId == productId);

            if (item != null)
            {
                if (action == "increase")
                    item.Quantity++;
                else if (action == "decrease" && item.Quantity > 1)
                    item.Quantity--;
            }

            Session["Cart"] = cart;
            return RedirectToAction("ViewCart");
        }



        public ActionResult Clear()
        {
            Session["Cart"] = null;
            return RedirectToAction("ViewCart");
        }
        // [HttpGet]
        //public ActionResult PlaceOrder()
        //{
        //    var cart = GetCart();
        //    if (!cart.Any())
        //        return RedirectToAction("ViewCart");

        //    return View(new OrderCreateDTO()); // or just redirect to checkout
        //}




        // [ValidateAntiForgeryToken]
        //public ActionResult PlaceOrder()
        //{
        //    var cart = GetCart(); // List<CartItem>

        //    if (cart == null || cart.Count == 0)
        //        return RedirectToAction("ViewCart");

        //    if (Session["UserId"] == null)
        //        return RedirectToAction("Login", "Account");

        //    int userId = Convert.ToInt32(Session["UserId"]);

        //    var cartDTOs = _mapper.Map<List<CartItemDTO>>(cart);

        //    var orderDto = new OrderCreateDTO
        //    {
        //        UserId = userId,
        //        CustomerName = "Sample",
        //        Address = "Hyderabad",
        //        Contact = "9999999999"
        //    };

        //    // ✅ Fix: pass both orderDto and cartDTOs
        //    _orderService.CreateOrder(orderDto, cartDTOs);

        //    // Clear cart
        //    Session["Cart"] = new List<CartItemDTO>();


        //    return RedirectToAction("OrderSuccess");
        //}

        [HttpPost]
        public ActionResult PlaceOrder()
        {
            var cart = Session["Cart"] as List<CartItemDTO>;
            if (cart == null || !cart.Any())
            {
                TempData["Error"] = "Cart is empty!";
                return RedirectToAction("ViewCart");
            }

            return View("Payment", new PaymentDTO());
        }

        [HttpPost]
        public ActionResult ConfirmOrder(PaymentDTO payment)
        {
            // validate card info (skip real validation)
            if (string.IsNullOrWhiteSpace(payment.CardNumber) || payment.CardNumber.Length < 12)
            {
                TempData["Error"] = "Invalid card details.";
                return View("Payment", payment);
            }

            int userId = Convert.ToInt32(Session["UserId"]);
            var cart = Session["Cart"] as List<CartItemDTO>;
            var dto = new OrderCreateDTO
            {
                UserId = userId,
                CustomerName = "John Doe", // You can fetch from session or user table
                Address = "123 Sample Street", // Fetch real user address
                Contact = "9876543210",       // Fetch real user phone
                Status = "Pending"
            };

            _orderService.CreateOrder(dto, cart);
            Session["Cart"] = null;

            return RedirectToAction("OrderSuccess");
        }

        public ActionResult Checkout()
        {
            var cart = GetCart();
            if (!cart.Any())
                return RedirectToAction("ViewCart");

            return View(cart);
        }
        public ActionResult OrderSuccess()
        {
            return View();
        }


    }
}
    

