using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TheScene.Areas.Admin.Constants.AdminConstants;

namespace TheScene.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize]
    public class BaseController : Controller
    {
    }
}
