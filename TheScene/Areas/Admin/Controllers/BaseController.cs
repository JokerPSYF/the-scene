// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-16-2022
//
// Last Modified By : Admin
// Last Modified On : 12-16-2022
// ***********************************************************************
// <copyright file="BaseController.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TheScene.Areas.Admin.Constants.AdminConstants;

namespace TheScene.Areas.Admin.Controllers
{
    /// <summary>
    /// Class BaseController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    [Area(Administrator)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = Administrator)]
    public class BaseController : Controller
    {
    }
}
