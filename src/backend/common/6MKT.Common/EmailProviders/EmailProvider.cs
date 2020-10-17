using _6MKT.Common.EmailProviders.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6MKT.Common.EmailProviders
{
    public class EmailProvider : IEmailProvider
    {
        private const string ApiKey = "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";
        private readonly EmailAddress _default;

        public EmailProvider() =>
            _default = new EmailAddress("esojep@hotmail.com", "Equipe 6MKT");


        public async Task SendPasswordAsync(PasswordEmailModel email) =>
            await SendEmail(email, new SendGridMessage
            {
                From = _default,
                Subject = "Sua senha de acesso chegou!!! UhuUuUlll",
                HtmlContent = $"<p>Olá {email.ToName}</p><p>Aqui está a sua senha: <strong style='color: blue'>{email.Password}</strong></p>"
            });

        public async Task SendPublishedOfferAsync(PublishedOfferEmailModel email) =>
            await SendEmail(email, new SendGridMessage
            {
                From = _default,
                Subject = $"Alguém acabou de publicar uma oferta na sua compra - {email.PurchaseTitle}",
                HtmlContent = $"<p>Olá!</p>A empresa {email.BusinessTradename} acabou de publicar uma oferta em sua compra: {email.PurchaseTitle}"
            });

        public async Task SendOfferSelectAsync(OfferSelectedEmailModel email) =>
            await SendEmail(email, new SendGridMessage
            {
                From = _default,
                Subject = "Sua oferta foi selecionada, corraa!",
                HtmlContent = $"<p>Olá!</p>{email.NaturalPersonName} acabou de selecionar a sua oferta para a compra: {email.PurchaseTitle}"
            });

        public async Task SendEmailToAllBusinessOnSubcategoryAsync(EmailsToBusiness businesses)
        {
            var emailsAddress = GetEmailAddress(businesses.Emails);

            var client = new SendGridClient(ApiKey);

            var msg = new SendGridMessage
            {
                From = _default,
                Subject = "Nova publicação de uma compra",
                HtmlContent = $"<p>Olá</p>Acabaram de publicar um desejo de compra.</br>Titulo: {businesses.PurchaseTitle}</br>Categoria: {businesses.SubcategoryName}"
            };

            msg.AddTos(emailsAddress.ToList());
            await client.SendEmailAsync(msg);
        }

        private IEnumerable<EmailAddress> GetEmailAddress(IEnumerable<Tuple<string, string>> emails) =>
            emails.Select(x => new EmailAddress(x.Item1, x.Item2));

        private static async Task SendEmail(BaseEmail email, SendGridMessage msg)
        {
            var client = new SendGridClient(ApiKey);

            msg.AddTo(new EmailAddress(email.ToEmail, email.ToName));

            await client.SendEmailAsync(msg);
        }
    }
}