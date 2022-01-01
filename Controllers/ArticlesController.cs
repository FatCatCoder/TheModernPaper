using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using ModernPaper.Models;
using ModernPaper.Services;

namespace ModernPaper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        ArticleService _service;
    
        public ArticlesController(ArticleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Article> GetAll()
        {
            return _service.GetAll();
        }

        // [HttpGet("{id}")]
        // public ActionResult<Pizza> GetById(int id)
        // {
        //     var pizza = _service.GetById(id);

        //     if(pizza is not null)
        //     {
        //         return pizza;
        //     }
        //     else
        //     {
        //         return NotFound();
        //     }
        // }
    }
}