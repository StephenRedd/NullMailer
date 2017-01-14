﻿using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace NullDesk.Extensions.Mailer.Core
{
    /// <summary>
    /// Mailer base class
    /// </summary>
    public interface ITemplateMailer<T> : IMailerSettings where T : class, IMailerTemplateSettings
    {
        /// <summary>
        /// Template settings 
        /// </summary>
        /// <returns></returns>
        T TemplateSettings { get; set; }

        /// <summary>
        /// Send mail using a template.
        /// </summary>
        /// <remarks>
        /// It is up to the implementing class to decide how to locate and use the specified template.
        /// </remarks>
        /// <param name="templateName">The template identifier.</param>
        /// <param name="toEmailAddress">To email address.</param>
        /// <param name="toDisplayName">To display name.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="replacementVariables">The replacement variables to use in the template.</param>
        /// <param name="attachmentFiles">A collection of paths to attachment files to include in the message.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> SendMailAsync(
            string templateName,
            string toEmailAddress,
            string toDisplayName,
            string subject,
            IDictionary<string, string> replacementVariables,
            IEnumerable<string> attachmentFiles,
            CancellationToken token);

        /// <summary>
        /// Send mail using a template.
        /// </summary>
        /// <param name="templateName">The template identifier.</param>
        /// <param name="toEmailAddress">To email address.</param>
        /// <param name="toDisplayName">To display name.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="replacementVariables">The replacement variables to use in the template.</param>
        /// <param name="attachments">A dictionary of attachments as streams</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <remarks>It is up to the implementing class to decide how to locate and use the specified template.</remarks>
        Task<bool> SendMailAsync(
            string templateName,
            string toEmailAddress,
            string toDisplayName,
            string subject,
            IDictionary<string, string> replacementVariables,
            IDictionary<string, Stream> attachments,
            CancellationToken token);

    }
}
