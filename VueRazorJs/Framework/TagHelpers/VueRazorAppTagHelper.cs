using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System;
using System.Linq;


namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-app", Attributes = "appId")]
    public class VueRazorAppTagHelper : TagHelper
    {
        [HtmlAttributeName("appId")]
        public string AppId { get; set; }

        [HtmlAttributeName("model")]
        public Object Model { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items.Add("id", AppId);
            output.TagName = "div";
            output.Attributes.Add(new TagHelperAttribute("id", AppId));
            output.Attributes.Add(new TagHelperAttribute("class", "vue-razor-app"));

            if (Model != null)
            {
                string modelJson = JsonConvert.SerializeObject(this.Model);

                var html = new HtmlString($"<div id='{AppId}-model' style='visibility: hidden'>{modelJson}</div>");
                output.PreContent.SetHtmlContent(html);
            }
        }
    }
}
