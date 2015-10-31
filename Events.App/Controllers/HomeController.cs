namespace Events.App.Controllers
{
    #region

    using System.Web.Mvc;

    #endregion

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return this.View();
        }
    }
}