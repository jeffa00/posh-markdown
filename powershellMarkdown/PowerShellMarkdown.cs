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
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string MarkdownContent 
        {
            get { return _markdownContent; }
            set { _markdownContent = value; }
        }

        private string _markdownContent = string.Empty;

        /// <summary>
        /// when true, (most) bare plain URLs are auto-hyperlinked  
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        [Parameter(
           Mandatory = false,
           HelpMessage = "When true, (most) bare plain URLs are auto-hyperlinked"
       )]
        public SwitchParameter AutoHyperlink
        {
            get { return _autoHyperlink; }
            set { _autoHyperlink = value; }
        }
        private bool _autoHyperlink = false;

        /// <summary>
        /// when true, RETURN becomes a literal newline  
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "When true, RETURN becomes a literal newline"
        )]
        public SwitchParameter AutoNewlines 
        {
            get { return _autoNewlines; }
            set { _autoNewlines = value; }
        }
        private bool _autoNewlines = false;

        /// <summary>
        /// use ">" for HTML output, or " />" for XHTML output
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Use \">\" for HTML output, or \" />\" for XHTML output"
        )]
        public string EmptyElementSuffix 
        {
            get { return _emptyElementSuffix;  }
            set { _emptyElementSuffix = value; }
        }
        private string _emptyElementSuffix = string.Empty;

        /// <summary>
        /// when true, problematic URL characters like [, ], (, and so forth will be encoded 
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "When true, problematic URL characters like [, ], (, and so forth will be encoded"
        )]
        public SwitchParameter EncodeProblemUrlCharacters 
        {
            get { return _encodeProblemUrlCharacters; }
            set { _encodeProblemUrlCharacters = value; }
        }
        private bool _encodeProblemUrlCharacters = false;

        /// <summary>
        /// when false, email addresses will never be auto-linked  
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "When false, email addresses will never be auto-linked"
        )]
        public SwitchParameter LinkEmails 
        {
            get { return _linkEmails ; }
            set { _linkEmails = value; }
        }
        private bool _linkEmails = false;

        /// <summary>
        /// when true, bold and italic require non-word characters on either side  
        /// WARNING: this is a significant deviation from the markdown spec
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "When true, bold and italic require non-word characters on either side"
        )]
        public SwitchParameter StrictBoldItalic 
        {
            get { return _strictBoldItalic ; }
            set { _strictBoldItalic = value; }
        }
        private bool _strictBoldItalic = false;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            if (MarkdownContent != null && MarkdownContent.Length > 0)
            {
                MarkdownOptions options = new MarkdownOptions
                {
                    AutoHyperlink = this.AutoHyperlink,
                    AutoNewlines = this.AutoNewlines,
                    EmptyElementSuffix = this.EmptyElementSuffix,
                    EncodeProblemUrlCharacters = this.EncodeProblemUrlCharacters,
                    LinkEmails = this.LinkEmails,
                    StrictBoldItalic = this.StrictBoldItalic
                };

                Markdown markyMark = new Markdown(options);

                WriteObject(markyMark.Transform(MarkdownContent));

            }
        }
    }
}
