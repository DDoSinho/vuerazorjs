using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table", Attributes = "datasource")]
    public class VueRazorTableTagHelper : TagHelper
    {
        [HtmlAttributeName("datasource")]
        public IList DataSource { get; set; }

        [HtmlAttributeName("columnnames")]
        public IList<string> ColumnNames { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (this.DataSource != null && this.DataSource.Count > 0)
            {
                string dataSourceJson = JsonConvert.SerializeObject(this.DataSource);

                var htmlBuilder = new StringBuilder($"<div id='app-datasource' style='visibility: hidden'>{dataSourceJson}</div>");

                htmlBuilder.Append($"<table class='table'>");

                if (this.ColumnNames != null)
                {
                    var thBuilder = new StringBuilder();

                    foreach (var name in this.ColumnNames)
                    {
                        thBuilder.Append($"<th scope='col'>{name}</th>");
                    }

                    htmlBuilder.Append($"<thead><tr>{thBuilder.ToString()}</tr></thead>");
                }



                var trBuilder = new StringBuilder();
                for (int i =0; i < this.DataSource.Count; i++)
                {
                    trBuilder.Append("<tr>");

                    var dataSourceProperties = this.DataSource[i].GetType().GetProperties();

                    foreach (var property in dataSourceProperties)
                    {
                        trBuilder.Append($"<td>{{{{datasource[{i}].{property.Name}}}}}</td>");
                    }

                    trBuilder.Append("</tr>");
                }

                htmlBuilder.Append($"<tbody>{trBuilder.ToString()}</tbody>");
                htmlBuilder.Append($"</table>");

                output.Content.AppendHtml(new HtmlString(htmlBuilder.ToString()));
            }
            else
            {
                //TODO: handle empty datasource
            }
        }
    }
}
