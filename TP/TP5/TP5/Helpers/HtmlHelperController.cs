using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TP5.Models.ViewModels;

namespace TP5.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString CustomSubmit(this HtmlHelper<PizzaViewModel> htmlHelper, PizzaViewModel vm, string nameValue)
        {


            //< div class="form-group">
            //    <div class="col-md-offset-2 col-md-10">
            //        <input type = "submit" value="Créer" class="btn btn-default" />
            //    </div>
            //</div>
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("form-group");
            var innerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("col-md-offset-2 col-md-10");
            var input = new TagBuilder("input");
            input.AddCssClass("btn btn-default");
            input.MergeAttribute("type", "submit");
            input.MergeAttribute("value", nameValue);

            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append(outerDiv.ToString(TagRenderMode.StartTag));
            htmlBuilder.Append(innerDiv.ToString(TagRenderMode.StartTag));
            htmlBuilder.Append(input.ToString(TagRenderMode.Normal));
            htmlBuilder.Append(innerDiv.ToString(TagRenderMode.EndTag));
            htmlBuilder.Append(outerDiv.ToString(TagRenderMode.EndTag));
            outerDiv.InnerHtml = htmlBuilder.ToString();
            var html = outerDiv.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(html);
        }
    }
}