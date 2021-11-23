﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index(int productPage = 1) =>
            View(repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
            .Take(PageSize));
    }
}
