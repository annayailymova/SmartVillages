using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MON;

public static class GlobalViewData
{
    static readonly bool IsDeploy = true;
    public static void Append(PageModel model, ViewDataDictionary viewData)
    {
        string suffix = IsDeploy ? ".html" : "";
        string basePath = model.HttpContext.Request.GetDisplayUrl();
        int depth = basePath.Split('/').Length - 4;
        // Console.WriteLine(basePath);
        // Console.WriteLine(depth);

        string prefix = depth == 0 ? "" : string.Concat(Enumerable.Repeat("../", depth));

        viewData["HtmlUrl_Index"] = "https://mmda.ipt.kpi.ua/en/projects/";//prefix + "Index" + suffix;
        viewData["HtmlUrl_MON"] = prefix + "MON" + suffix;
        viewData["HtmlUrl_MON_Products"] = prefix + "MON/Products" + suffix;
        viewData["ResourcesUrl_MON_Products"] = prefix + "products/MON";
        viewData["ResourcesUrl_Css"] = prefix + "css";
        viewData["ResourcesUrl_Images"] = prefix + "images";
        viewData["ResourcesUrl_Js"] = prefix + "js";
        viewData["RootUrl"] = prefix;
    }
}