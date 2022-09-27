using CMS.SiteProvider;
using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using KenticoURLRedirection;

namespace KenticoURLRedirection
{
    public static class RedirectionExtensions
    {
        public static IApplicationBuilder UseRedirectionModule(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.Use(async (context, next) =>
            {
                //Redirection Module Handling and Lowercase URL Enforcement
                //Custom lowercase URL enforcement needed as these custom handling methods cause the Kentico lowercase enforcement to no longer function
                string url = context.Request.Path.Value;
                string handler = url.Split('/')[1].ToLower();
                string[] aliasesToExclude = { "cmspages", "cmsmodules", "cmsformcontrols", "cmsadmincontrols", "admin", "getattachment", "getfile", "getmedia", "getmetafile", "app_themes", "cmsapi", "socialmediaapi", "searchapi", "formsapi", "api", "cmsctx", "_content" };

                //Redirect /admin to admin domain
                //if (url == "/admin")
                //{
                //    //This is not the most efficient way of doing it, but should be fine as it is for a single alias for a single redirect
                //    var allAliases = SiteDomainAliasInfo.Provider.Get().WhereEquals("SiteID", SiteContext.CurrentSiteID).ToList();
                //    var domainAlias = allAliases.Where(a => a.SiteDomainPresentationUrl.Replace("http://", "").Replace("https://", "").TrimEnd('/').ToLower() == context.Request.Host.Value.ToLower()).FirstOrDefault();

                //    if (domainAlias != null)
                //    {
                //        context.Response.Redirect($"{(context.Request.IsHttps ? "https" : "http")}://{domainAlias.SiteDomainAliasName}");
                //        return;
                //    }

                //    else
                //    {
                //        context.Response.Redirect($"{(context.Request.IsHttps ? "https" : "http")}://{SiteContext.CurrentSite.DomainName}");
                //        return;
                //    }
                //}

                if (!aliasesToExclude.Contains(handler) && !handler.StartsWith("kentico") && SiteContext.CurrentSite != null)
                {
                    //Originally was a static class but changed to non-static as it caused issues with caching
                    var redirectionHelper = new RedirectionHelper();

                    var response = redirectionHelper.GetRedirect(url);

                    //Redirection Check and Handler
                    if (!String.IsNullOrEmpty(response.FinalUrl))
                    {
                        context.Response.Redirect(response.FinalUrl, response.PermanentRedirect);
                        return;
                    }

                    //Lowercase URL Check and Enforcement
                    if (url != url.ToLower())
                    {
                        context.Response.Redirect(url.ToLower(), true);
                        return;
                    }
                }

                await next();
            });
        }
    }
}
