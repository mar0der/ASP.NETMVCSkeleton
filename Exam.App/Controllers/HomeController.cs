namespace Exam.App.Controllers
{
    #region

    using System;
    using System.Web.Mvc;

    using Exam.App.Extensions;
    using Exam.Data.Contracts;
    using Exam.Models.Models;

    #endregion

    public class HomeController : BaseController
    {
        public HomeController(IExamData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            var model = new Event()
                            {
                                Id = 1
                               // StartTime = DateTime.Now
                            };
            return this.View(model);
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return this.View();
        }
    }
}