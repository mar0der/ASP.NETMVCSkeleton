namespace Events.App.Areas.Admin.Controllers
{
    #region

    using System.Web.Mvc;

    using Events.App.Controllers;
    using Events.Common;
    using Events.Data.Contracts;

    using WebGrease.Configuration;

    #endregion

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(IEventsData data)
            : base(data)
        {
        }

    }
}