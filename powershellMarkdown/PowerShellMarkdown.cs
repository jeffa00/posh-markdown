using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using MarkdownSharp;


namespace powershellMarkdown
{
    [Cmdlet(VerbsData.ConvertFrom, "Markdown")]
    public class PowerShellMarkdown : PSCmdlet
    {
        [Parameter(
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string[] MarkdownContent { get; set; }

        protected override void ProcessRecord()
        {
            if (MarkdownContent != null && MarkdownContent.Length > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in MarkdownContent)
                {
                    sb.Append(item + "\n");
                }

                Markdown markyMark = new Markdown();

                WriteObject(markyMark.Transform(sb.ToString()));

            }
        }
    }
}
