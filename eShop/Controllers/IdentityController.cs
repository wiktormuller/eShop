using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eShop.Controllers
{
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
