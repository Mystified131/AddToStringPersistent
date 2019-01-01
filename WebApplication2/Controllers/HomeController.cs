using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        static public string Searchstr;

        public IActionResult Index()
        {

            IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public IActionResult Error()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Result()
        {
            List<Stringelement> TheList = context.Stringelements.ToList();


            if (TheList.Count > 0)

            {

                ResultViewModel resultViewModel = new ResultViewModel();

                StringBuilder Builder = new StringBuilder();

                foreach(var item in TheList)
                {
                    Builder.Append(item.Element);

                }

                string Buildlist = Builder.ToString();
                resultViewModel.TheString = Buildlist;

                return View(resultViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Result(ResultViewModel resultViewModel)

        {

            if (ModelState.IsValid)
            {

                Stringelement thestr = new Stringelement(resultViewModel.NewElement.ToLower());
                context.Stringelements.Add(thestr);
                context.SaveChanges();

                List<Stringelement> TheList = context.Stringelements.ToList();

                StringBuilder Builder = new StringBuilder();

                foreach (var item in TheList)
                {
                    Builder.Append(item.Element);

                }

                string Buildlist = Builder.ToString();


                resultViewModel.TheString = Buildlist;

                return View(resultViewModel);
            }


            return Redirect("/Home/Error");

        }



        [HttpGet]
        public IActionResult EditItem()
        {
            List<Stringelement> TheList = context.Stringelements.ToList();


            if (TheList.Count > 0)
            {
                StringBuilder Builder = new StringBuilder();

                foreach (var item in TheList)
                {
                    Builder.Append(item.Element);

                }

                string Buildlist = Builder.ToString();


                ViewBag.NewElement1 = Buildlist;


                EditItemViewModel editItemViewModel = new EditItemViewModel();

                return View(editItemViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult EditItem(EditItemViewModel editItemViewModel)

        {
            List<Stringelement> TheList = context.Stringelements.ToList();

            if (ModelState.IsValid & TheList.Count > 0)

            {
                foreach(var item in TheList)
                {
                    item.Element = "";

                }

                context.SaveChanges();


                Stringelement thestr = new Stringelement(editItemViewModel.NewElement2.ToLower());
                context.Stringelements.Add(thestr);
                context.SaveChanges();

                return Redirect("/Home/Result");
            }

            { 
            return Redirect("/Home/Error");

        }

    }

        [HttpGet]
        public IActionResult SearchSelect()
        {
            List<Stringelement> TheList = context.Stringelements.ToList();

            if (TheList.Count > 0)
            {
                SearchSelectViewModel searchSelectViewModel = new SearchSelectViewModel();

                return View(searchSelectViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult SearchSelect(SearchSelectViewModel searchSelectViewModel)

        {
            List<Stringelement> TheList = context.Stringelements.ToList();

            if (ModelState.IsValid & TheList.Count > 0)

            {
                Searchstr = searchSelectViewModel.Searchstr.ToLower();
                return Redirect("/Home/SearchResult");
            }

            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult SearchResult()
        {
            List<Stringelement> TheList = context.Stringelements.ToList();

            if (TheList.Count > 0)
            {
                StringBuilder Builder = new StringBuilder();

                foreach (var item in TheList)
                {
                    Builder.Append(item.Element);

                }

                string Buildlist = Builder.ToString();


                string thestr = Buildlist;

                SearchResultViewModel searchResultViewModel = new SearchResultViewModel();

                if (thestr.Contains(Searchstr))
                {

                    bool Anslist = true;
                    ViewBag.Anslist = Anslist;
                    ViewBag.TheString = thestr;
                    ViewBag.Searchstr = Searchstr;

                    return View(searchResultViewModel);
                }

                else
                {

                    bool Anslist = false;
                    ViewBag.Anslist = Anslist;
                    ViewBag.TheString = thestr;
                    ViewBag.Searchstr = Searchstr;

                    return View(searchResultViewModel);

                }
            }

            else
            {
                return Redirect("/");
            }
        }


        [HttpGet]
        public IActionResult Sort()
        {
            List<Stringelement> TheList = context.Stringelements.ToList();


            if (TheList.Count > 0)
            {
                StringBuilder Builder = new StringBuilder();

                foreach (var item in TheList)
                {
                    Builder.Append(item.Element);

                }

                string Buildlist = Builder.ToString();


                string thestr = Buildlist;

                SortViewModel sortViewModel = new SortViewModel();

                List<char> Bridgelist = new List<char>();

                foreach (char item in thestr)
                {

                    Bridgelist.Add(item);

                }

                Bridgelist.Sort();

                var builder = new StringBuilder();

                foreach (char item in Bridgelist)
                {

                    builder.Append(item);

                }

                sortViewModel.Sortstring = builder.ToString();

                return View(sortViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

    }

}
