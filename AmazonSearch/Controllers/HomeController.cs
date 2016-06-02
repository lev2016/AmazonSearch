using System;
using System.Linq;
using System.Web.Mvc;
using AmazonSearch.Models;
using System.Collections.Generic;

namespace AmazonSearch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            string Keywords = "Gravity falls Mabel figure";

            AmazonQuery search = new AmazonQuery();

            string SearchIndex = "All";
            string[] SearchResponseGroup = new string[] { "Medium" };

            var searchResponse = search.ItemSearch(SearchIndex, SearchResponseGroup, Keywords);

            List<ItemModel> itemModels = new List<ItemModel>();

            for(int i = 0; i < searchResponse.Items[0].Item.Count(); i++)
            {
                var newItem = new ItemModel();
                newItem.Title = searchResponse.Items[0].Item[i].ItemAttributes.Title;
                newItem.Manufacturer = searchResponse.Items[0].Item[i].ItemAttributes.Manufacturer;
                if (searchResponse.Items[0].Item[i].ItemAttributes.ListPrice != null)
                {
                    newItem.Price = searchResponse.Items[0].Item[i].ItemAttributes.ListPrice.Amount;
                }
                else
                {
                    newItem.Price = "Unfortunately, there is no price availible";
                }
                itemModels.Add(newItem);
            }

            return View(itemModels);
        }
    }
  
}