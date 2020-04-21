using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Optimization;
using System.Web.UI;


namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {



        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            BundleTable.Bundles.Add(new ScriptBundle("~/opti-bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));


            BundleTable.Bundles.Add(new ScriptBundle("~/opti-bundles/WebFormsJs").Include(
               "~/Scripts/WebForms/WebForms.js",
               "~/Scripts/WebForms/WebUIValidation.js",
               "~/Scripts/WebForms/MenuStandards.js",
               "~/Scripts/WebForms/Focus.js",
               "~/Scripts/WebForms/GridView.js",
               "~/Scripts/WebForms/DetailsView.js",
               "~/Scripts/WebForms/TreeView.js",
               "~/Scripts/WebForms/WebParts.js"));

            BundleTable.Bundles.Add(new StyleBundle("~/opti-bundles/management-css").Include(
                "~/css/gridsta/stylesheet.css"));

            BundleTable.Bundles.Add(new StyleBundle("~/opti-bundles/session-css").Include(
                "~/css/session/stylesheet.css"));

            // add timer.js to allow timer functionality on school class programme session video page 0303
            // added fivesm.js to allow checkbox functionality on school programme view page 2912
            // add main.js to allow more functionality for session page 0302
            BundleTable.Bundles.Add(new ScriptBundle("~/opti-bundles/management-js").Include(
                "~/Scripts/custom/vendors/fivesm.js",
                "~/Scripts/custom/vendors/modernizr-custom.js",
                "~/Scripts/custom/vendors/jquery.notey-fi.js",
                "~/Scripts/custom/vendors/tooltipster.main.js",
                "~/Scripts/custom/vendors/svg4everybody.js",
                "~/Scripts/custom/vendors/jquery.scrollbar.js",
                "~/Scripts/custom/vendors/dragscroll.js",
                "~/Scripts/custom/vendors/responsivegraphs.js",
                "~/Scripts/custom/management-main.js",
                "~/Scripts/custom/vendors/teach.js",
                "~/Scripts/custom/vendors/timer.js",
                "~/Scripts/main.js"
                ));

            string JQueryVer = "3.3.1";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
                CdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });

            ScriptManager.ScriptResourceMapping.AddDefinition("WebFormsBundle", new ScriptResourceDefinition
            {
                Path = "~/opti-bundles/WebFormsJs",
                CdnPath = "https://ajax.aspnetcdn.com/ajax/4.5.1/1/WebFormsBundle.js",
                LoadSuccessExpression = "window.WebForm_PostBackOptions",
                CdnSupportsSecureConnection = true
            });

            ScriptManager.ScriptResourceMapping.AddDefinition("MsAjaxBundle", new ScriptResourceDefinition
            {
                Path = "~/opti-bundles/MsAjaxJs",
                CdnPath = "https://ajax.aspnetcdn.com/ajax/4.5.1/1/MsAjaxBundle.js",
                LoadSuccessExpression = "window.Sys",
                CdnSupportsSecureConnection = true
            });
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}