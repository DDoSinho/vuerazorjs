using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using VueRazorJs.Framework.VueRazorTable;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table", Attributes = "datasource")]
    [RestrictChildren("vue-razor-table-column", new string[] { "vue-razor-table-paginator" })]
    public class VueRazorTableTagHelper : TagHelper
    {
        [HtmlAttributeName("datasource")]
        public IList DataSource { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "vue-razor-table-container");

            var vueRazorTable = new Table()
            {
                Columns = new List<ColumnContext>(),
                DataSource = this.DataSource
            };

            context.Items.Add(typeof(VueRazorTableTagHelper), vueRazorTable);

            await output.GetChildContentAsync();

            if (this.DataSource != null && this.DataSource.Count > 0)
            {
                string dataSourceJson = JsonConvert.SerializeObject(this.DataSource);

                var htmlBuilder = new StringBuilder($"<div class='datasource' style='visibility: hidden'>{dataSourceJson}</div>");

                var cssClass = context.AllAttributes.Where(all => all.Name == "class").Select(all => all.Value.ToString()).FirstOrDefault();
                htmlBuilder.Append($"<table class='{cssClass}'>");

                var columnNames = new List<string>();
                var dataSourceContainedType = this.DataSource[0].GetType();

                var thBuilder = new StringBuilder();

                foreach (var column in vueRazorTable.Columns)
                {
                    using (var writer = new System.IO.StringWriter())
                    {
                        column.HeaderContent.Content.WriteTo(writer, HtmlEncoder.Default);
                        var headerContent = writer.ToString();

                        thBuilder.Append($"<th scope='col' class='{column.HeaderContent.CssClasses}'>{headerContent}</th>");
                    }
                }

                if (vueRazorTable?.Paginator.PaginatorPosition == Position.Both ||
                    vueRazorTable?.Paginator.PaginatorPosition == Position.Over)
                {
                    htmlBuilder.Append(vueRazorTable.Paginator.PaginatorHtmlString);
                }

                htmlBuilder.Append($"<thead><tr>{thBuilder.ToString()}</tr></thead>");

                var trBuilder = new StringBuilder();
                for (int i = 0; i < this.DataSource.Count; i++)
                {
                    trBuilder.Append("<tr>");

                    foreach (var column in vueRazorTable.Columns)
                    {
                        using (var writer = new System.IO.StringWriter())
                        {
                            column.RowContent.Content.WriteTo(writer, HtmlEncoder.Default);
                            var htmlContent = writer.ToString().Replace("row."+column.For, $"datasource[{i}].{column.For}");

                            trBuilder.Append($"<td class={column.RowContent.CssClasses}>{htmlContent}</td>");
                        }

                    }

                    trBuilder.Append("</tr>");
                }

                htmlBuilder.Append($"<tbody>{trBuilder.ToString()}</tbody>");
                htmlBuilder.Append($"</table>");

                if (vueRazorTable?.Paginator.PaginatorPosition == Position.Both ||
                   vueRazorTable?.Paginator?.PaginatorPosition == Position.Bottom)
                {
                    htmlBuilder.Append(vueRazorTable.Paginator.PaginatorHtmlString);
                }

                output.Content.SetHtmlContent(htmlBuilder.ToString());
            }
            else
            {
                //TODO: handle empty datasource
            }
        }
    }
}
