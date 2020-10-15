using _6MKT.Common.EmailProviders.Models;
using System.Threading.Tasks;

namespace _6MKT.Common.EmailProviders
{
    public interface IEmailProvider
    {
        Task SendPasswordAsync(PasswordEmailModel emailModel);
        Task SendPublishedOfferAsync(PublishedOfferEmailModel email);
        Task SendOfferSelectAsync(OfferSelectedEmailModel email);
        Task SendEmailToAllBusinessOnSubcategoryAsync(EmailsToBusiness businesses);
    }
}