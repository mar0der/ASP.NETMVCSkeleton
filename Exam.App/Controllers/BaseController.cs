namespace Exam.App.Controllers
{
    #region

    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Exam.Data.Contracts;
    using Exam.Models.Models;

    #endregion

    [Authorize]
    public class BaseController : Controller
    {
        public BaseController(IExamData data)
        {
            this.Data = data;
        }

        public BaseController(IExamData data, User currentUser)
        {
            this.Data = data;
            this.CurrentUser = currentUser;
        }

        public IExamData Data { get; private set; }

        public User CurrentUser { get; set; }

        protected override IAsyncResult BeginExecute(
            RequestContext requestContext,
            AsyncCallback callback,
            object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.CurrentUser = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}