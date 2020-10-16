namespace _6MKT.BackOffice.Domain.Constants
{
    public class MessageExceptionConstants
    {
        public const string PurchaseFinishOrCancelException = "Compra finalizada ou cancelada";
        public const string NotFoundException = "Item não encontrado";
        public const string CreateTwoOfferOnSamePurchaseException = "Você já fez uma oferta a está compra.";
        public const string NotInYourSubcategoriesException = "Você não está inscrito na subcategoria dessa compra.";
        public const string RegisteredException = "Item já registrado em nossa base de dados";
        public const string EmailRegisteredException = "Email já cadastrado em nossa base de dados.";
        public const string RelatedWithAnotherObject = "Esse item está relacionado a outro objeto";
    }
}