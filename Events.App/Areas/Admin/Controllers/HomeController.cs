namespace Events.App.Areas.Admin.Controllers
{
    #region

    using System.Web.Mvc;

    using Events.Data.Contracts;

    #endregion

    public class HomeController : BaseAdminController
    {
        public HomeController(IEventsData data)
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