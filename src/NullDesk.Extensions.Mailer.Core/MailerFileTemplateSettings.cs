﻿using System.Collections.Generic;

namespace NullDesk.Extensions.Mailer.Core
{
    /// <summary>
    /// Settings for SMTP Email Services.
    /// </summary>
    public class MailerFileTemplateSettings : IMailerTemplateSettings
    {

        /// <summary>
        /// The folder path where templates are stored.
        /// </summary>
        /// <value>The template path.</value>
        public string TemplatePath { get; set; }

        /// <summary>
        /// Collection of possible HTML template file name extensions
        /// </summary>
        /// <value>The HTML template file extensions.</value>
        public IEnumerable<string> HtmlTemplateFileExtensions { get; set; } = new [] {"htm", "html"};

        /// <summary>
        /// Gets or sets the text template file extension.
        /// </summary>
        /// <value>The text template file extension.</value>
        public IEnumerable<string> TextTemplateFileExtension { get; set; } = new [] {"txt"};

    }
}
