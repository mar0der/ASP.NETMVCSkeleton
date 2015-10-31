namespace Events.App.Areas.Admin.Controllers
{
    #region

    using System.Web.Mvc;

    #endregion

    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return this.View();
        }
    }
}