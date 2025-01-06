using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;

namespace CashFlow.Domain.Extensions
{
    public static class PaymentTypeExtensions
    {
        public static string PaymentTypeToString(this EPaymentType paymentType)
        {
            return paymentType switch
            {
                EPaymentType.Cash => ResourceReportGenerationMessages.CASH,
                EPaymentType.CreditCard => ResourceReportGenerationMessages.CREDIT_CARD,
                EPaymentType.DebitCard => ResourceReportGenerationMessages.DEBIT_CARD,
                EPaymentType.EletronicTransfer => ResourceReportGenerationMessages.ELETRONIC_TRANSFER,
                _ => string.Empty
            };
        }
    }
}
