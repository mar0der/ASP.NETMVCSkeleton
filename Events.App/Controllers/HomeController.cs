namespace Events.App.Controllers
{
    #region

    using System.Web.Mvc;

    using Events.Data.Contracts;

    #endregion

    public class HomeController : BaseController
    {
        public HomeController(IEventsData data)
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
    }
}