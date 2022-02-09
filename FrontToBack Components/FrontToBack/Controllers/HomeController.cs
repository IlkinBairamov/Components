using FrontToBack.DataAccessLayer;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var sliderImage = await _dbContext.SliderImages.ToListAsync();
            var slider = await _dbContext.Sliders.SingleOrDefaultAsync();
            var category = await _dbContext.Categories.ToListAsync();
           // var product = _dbContext.Products.Include(x=>x.Category).Take(4).ToListAsync();
            var aboutsection = await _dbContext.AboutSections.SingleOrDefaultAsync();
            var aboutsectionimage = await _dbContext.AboutSectionImages.SingleOrDefaultAsync();
            var aboutsectionlist = await _dbContext.AboutSectionLists.ToListAsync();
            var expertsection = await _dbContext.ExpertSections.SingleOrDefaultAsync();
            var expertsectionlist = await _dbContext.ExpertSectionLists.ToListAsync();
            var blog = await _dbContext.Blogs.SingleOrDefaultAsync();
            var bloglist = await _dbContext.BlogLists.ToListAsync();
            var slidersay = await _dbContext.SliderSays.ToListAsync();
            var subscribe = await _dbContext.Subscribes.SingleOrDefaultAsync();
            var instagram = await _dbContext.Instagrams.ToListAsync();

            return View(new HomeViewModel { 
                SliderImage=  sliderImage,
                Slider=  slider,
                Categories=  category,
               //Products= await product,
                AboutSections= aboutsection,
                AboutSectionImages=  aboutsectionimage,
                AboutSectionLists=  aboutsectionlist,
                ExpertSections =  expertsection,
                ExpertSectionLists=  expertsectionlist,
                Blogs=  blog,
                BlogLists=  bloglist,
                SliderSays=  slidersay,
                Subscribes=  subscribe,
                Instagrams=  instagram
            });
        }
    }
}
