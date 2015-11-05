namespace Exam.App.Areas.Admin.Controllers
{
    #region

    using System.Web.Mvc;

    using Exam.App.Controllers;
    using Exam.Common;
    using Exam.Data.Contracts;

    #endregion

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(IExamData data)
            : base(data)
        {
        }

    }
}