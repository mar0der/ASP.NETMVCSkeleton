namespace Exam.App.Controllers
{
    #region

    using System.Web.Mvc;

    using Exam.Data.Contracts;

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
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return this.View();
        }
    }
}