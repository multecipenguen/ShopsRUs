using ShopsRUs.Application.Constants;
using ShopsRUs.Domain.Entities;

namespace ShopsRUs.Application.Services
{
    public class DiscountCountService
    {

        public static decimal Calculate(decimal Amount, Discount discount)
        {
            if (discount.Type.ToLower() == CampaignDiscounts.Per100DollarDiscount.ToLower())
            {
                double percentageAmountApply = discount.Percentage * (int)(Amount / 100);

                return Amount - (Amount * ((decimal)percentageAmountApply / 100));
            }
            else
            {
                return Amount - (Amount * ((decimal)discount.Percentage / 100));
            }
        }
    }
}
