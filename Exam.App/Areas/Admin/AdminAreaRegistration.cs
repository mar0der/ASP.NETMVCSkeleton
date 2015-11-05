namespace Exam.App.Areas.Admin
{
    #region

    using System.Web.Mvc;

    #endregion

    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default", 
                "Admin/{controller}/{action}/{id}", 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Exam.App.Areas.Admin.Controllers" });
        }
    }
}