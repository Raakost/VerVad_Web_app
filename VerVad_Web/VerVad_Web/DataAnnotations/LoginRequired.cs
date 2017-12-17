using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerVad_Web.DataAnnotations
{
        public class LoginRequired : AuthorizeAttribute
        {
            protected override void HandleUnauthorizedRequest(AuthorizationContext context)
            {
                UrlHelper urlHelper = new UrlHelper(context.RequestContext);
                if (HttpContext.Current.Session["token"] == null)
                    context.Result = new RedirectResult(urlHelper.Action("Login", "Account"));
            }
        }
    }
