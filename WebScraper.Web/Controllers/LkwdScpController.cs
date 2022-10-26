using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.Scraper;

namespace WebScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LkwdScpController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<LkwdScpItm> Scrape()
        {
            return LkwdScpScraper.Scrape();
        }
    }
}
