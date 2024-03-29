﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASP.netCoreTreningApp.TagHelpers
{
    [HtmlTargetElement("table", Attributes = "bootstrap-table")]
    public class BootstrapTableTagHelper : TagHelper
    {
        public string TableName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreElement.AppendHtml($"<h2>{TableName}</h2>");
            output.Attributes.Add(new TagHelperAttribute("class", "table table-striped table-hover table-sm"));
        }
    }
}
