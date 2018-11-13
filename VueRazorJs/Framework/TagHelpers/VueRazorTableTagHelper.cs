using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueRazorJs.Framework.Attributes;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table", Attributes = "datasource")]
    public class VueRazorTableTagHelper : TagHelper
    {
        [HtmlAttributeName("datasource")]
        public IList DataSource { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("id", "vrt");

            if (this.DataSource != null && this.DataSource.Count > 0)
            {
                string dataSourceJson = JsonConvert.SerializeObject(this.DataSource);

                var htmlBuilder = new StringBuilder($"<div class='datasource' style='visibility: hidden'>{dataSourceJson}</div>");

                htmlBuilder.Append($"<table class='table'>");

                var columnNames = new List<string>();
                var dataSourceContainedType = this.DataSource[0].GetType();

                foreach (var property in dataSourceContainedType.GetProperties())
                {
                    var attributes = property.GetCustomAttributes(true);

                    if (attributes.Length > 0)
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is VueRazorTableDisplayName)
                            {
                                columnNames.Add((attribute as VueRazorTableDisplayName).Name);
                            }
                        }
                    }
                    else
                    {
                        columnNames.Add(property.Name);
                    }
                }

                if (columnNames != null)
                {
                    var thBuilder = new StringBuilder();

                    foreach (var name in columnNames)
                    {
                        thBuilder.Append($"<th scope='col'>{name}</th>");
                    }

                    htmlBuilder.Append($"<thead><tr>{thBuilder.ToString()}</tr></thead>");
                }

                var trBuilder = new StringBuilder();
                for (int i = 0; i < this.DataSource.Count; i++)
                {
                    trBuilder.Append("<tr>");

                    var dataSourceProperties = dataSourceContainedType.GetProperties();

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
