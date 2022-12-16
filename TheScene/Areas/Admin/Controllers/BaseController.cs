using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TheScene.Areas.Admin.Constants.AdminConstants;

namespace TheScene.Areas.Admin.Controllers
{
    [Area(Administrator)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = Administrator)]
    public class BaseController : Controller
    {
    }
}
