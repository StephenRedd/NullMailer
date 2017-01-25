﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NullDesk.Extensions.Mailer.Core;
using SendGrid;

namespace NullDesk.Extensions.Mailer.SendGrid
{
    /// <summary>
    /// Class MailerFactoryExtensions.
    /// </summary>
    public static class MailerFactoryExtensions
    {

        /// <summary>
        /// Register a SendGrid simplified mailer with the factory.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="settings">The mailer settings.</param>
        /// <param name="logger">The logger.</param>
        public static void RegisterSendGridSimpleMailer(this MailerFactory factory, SendGridMailerSettings settings, ILogger<SendGridSimpleMailer> logger = null)
        {
            factory.RegisterMailer(() => new SendGridSimpleMailer(
                new OptionsWrapper<SendGridMailerSettings>(settings),
                logger));
        }

        /// <summary>
        /// Register a SendGrid simplified mailer with the factory.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="client">The client.</param>
        /// <param name="settings">The mailer settings.</param>
        /// <param name="logger">The logger.</param>
        public static void RegisterSendGridSimpleMailer(this MailerFactory factory, Client client, SendGridMailerSettings settings, ILogger<SendGridSimpleMailer> logger = null)
        {
            factory.RegisterMailer(() => new SendGridSimpleMailer(
                client,
                new OptionsWrapper<SendGridMailerSettings>(settings),
                logger));
        }

        /// <summary>
        /// Register a SendGrid mailer with the factory.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="settings">The mailer settings.</param>
        /// <param name="logger">The logger.</param>
        public static void RegisterSendGridMailer(this MailerFactory factory, SendGridMailerSettings settings, ILogger<SendGridMailer> logger = null)
        {
            factory.RegisterMailer(() => new SendGridMailer(
                new OptionsWrapper<SendGridMailerSettings>(settings),
                logger));
        }

        /// <summary>
        /// Register a SendGrid mailer with the factory.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="client">The sendgrid client.</param>
        /// <param name="settings">The mailer settings.</param>
        /// <param name="logger">The logger.</param>
        public static void RegisterSendGridMailer(this MailerFactory factory, 
            Client client,
            SendGridMailerSettings settings, 
            ILogger<SendGridMailer> logger = null)
        {
            factory.RegisterMailer(() => new SendGridMailer(
                client,
                new OptionsWrapper<SendGridMailerSettings>(settings),
                logger));
        }
    }
}