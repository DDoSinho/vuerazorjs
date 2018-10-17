using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System.Linq;


namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-app", Attributes = "model")]
    public class VueRazorAppTagHelper : TagHelper
    {
        [HtmlAttributeName("model")]
        public TempClass TempClass { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var appId = context.AllAttributes.Where(a => a.Name == "id").SingleOrDefault().Value;

            if (!string.IsNullOrEmpty(appId.ToString()))
            {
                output.TagName = "div";

                if (TempClass != null)
                {
                    string modelJson = JsonConvert.SerializeObject(this.TempClass);

                    var html = new HtmlString($"<div id='{appId}-model' style='visibility: hidden'>{modelJson}</div>");
                    output.PreContent.AppendHtml(html);
                }

            }
        }
    }
}
