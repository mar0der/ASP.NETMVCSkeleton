namespace Exam.App.Areas.Admin.Controllers
{
    #region

    using System.Web.Mvc;

    using Exam.Data.Contracts;

    #endregion

    public class HomeController : BaseAdminController
    {
        public HomeController(IExamData data)
            : base(data)
        {
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return this.View();
        }
    }
}