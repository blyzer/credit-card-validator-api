using Data.Enums;
using Data.MessageLists;
using Data.RequestModels;
using Managers.Helpers;
using Managers.IManagers;
using System.Text;
using System.Text.RegularExpressions;

namespace Managers.Managers
{
    public class CreditCardManager : ICreditCardManager
    {
        /// <summary>
        /// Validate Credit Card type and number
        /// </summary>
        /// <param name="creditCardValidation"></param>
        /// <returns>Validated List of Credit cards</returns>
        /// <exception cref="Exception">Not found</exception>
        public List<CreditCardInfoDto> ValidateCreditCards(CreditCardValidationDto creditCardValidation)
        {
            if (creditCardValidation != null && creditCardValidation.CreditCardNumbers.Count > 0)
            {
                List<CreditCardInfoDto> creditCardInfoList = new List<CreditCardInfoDto>();

                foreach (var creditCard in creditCardValidation.CreditCardNumbers)
                {
                    var creditCardInfo = ValidateCreditCardDigits(creditCard);
                    creditCardInfo = ValidateCreditCardFormattedText(creditCardInfo);
                    creditCardInfo = AssignCreditCardType(creditCardInfo);

                    creditCardInfoList.Add(creditCardInfo);
                }

                return creditCardInfoList;
            }
            else
            {
                throw new Exception(CreditCardValidationMessageList.Default.CreditCardsNotFound);
            }
        }

        /// <summary>
        /// Remove non digits and spaces from the credit card text
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns>Formatted credit card text</returns>
        private static CreditCardInfoDto ValidateCreditCardDigits(string creditCardNumber)
        {
            StringBuilder stringBuilder = new();

            foreach (char character in creditCardNumber)
            {
                if (Char.IsDigit(character))
                    stringBuilder.Append(character);
            }

            CreditCardInfoDto creditCardInfo = new()
            {
                CreditCardNumberText = creditCardNumber,
                FormattedCreditCardNumber = stringBuilder.ToString(),
                IsValidCreditCard = stringBuilder != null
            };

            return creditCardInfo;
        }

        /// <summary>
        /// Validate credit card text against the Luhn algorythm
        /// </summary>
        /// <param name="creditCardInfo"></param>
        /// <returns>Validate credit card info object against Luhn algorythm</returns>
        private static CreditCardInfoDto ValidateCreditCardFormattedText(CreditCardInfoDto creditCardInfo)
        {
            int oddIndexDigitTotal = 0, evenIndexDigitTotal = 0;

            for (int index = 0; index < creditCardInfo.FormattedCreditCardNumber.Length; index++)
            {
                //find first and every other digit values
                if (index == 0 || index % 2 == 0)
                {
                    var oddIndexNumber= ((creditCardInfo.FormattedCreditCardNumber[index] - '0') * 2).ToString();
                    //To check wether the multiplied number has more than one digit
                    if (oddIndexNumber.Length > 1)
                    {
                        oddIndexDigitTotal += (1 + (Int32.Parse(oddIndexNumber) % 10));
                    }
                    else
                    {
                        oddIndexDigitTotal += Int32.Parse(oddIndexNumber);
                    }
                }
                else
                    evenIndexDigitTotal += creditCardInfo.FormattedCreditCardNumber[index] - '0';
            }

            var digitsTotal = oddIndexDigitTotal + evenIndexDigitTotal;


            if (digitsTotal == 0 || digitsTotal % 10 != 0)
                creditCardInfo.IsValidCreditCard = false;

            return creditCardInfo;
        }

        /// <summary>
        /// Assign credit card type
        /// </summary>
        /// <param name="creditCardInfo"></param>
        /// <returns>Credit card info with type</returns>
        private static CreditCardInfoDto AssignCreditCardType(CreditCardInfoDto creditCardInfo)
        {
            //validate against the CreditCardTypeInfoList
            foreach (var creditCardTypeInfo in CreditCardTypeInfoHelper.CreditCardTypeInfoList)
            {
                //validate cc number length and card type
                if (creditCardInfo.FormattedCreditCardNumber.Length == creditCardTypeInfo.CardNumberLength &&
                    Regex.IsMatch(creditCardInfo.FormattedCreditCardNumber, creditCardTypeInfo.Regex))
                    creditCardInfo.CreditCardType = creditCardTypeInfo.CreditCardType.ToString();
            }

            //unknown card type: Invalid card number 
            if (string.IsNullOrEmpty(creditCardInfo.CreditCardType))
            {
                creditCardInfo.CreditCardType = CreditCardTypeEnum.Unknown.ToString();
                creditCardInfo.IsValidCreditCard = false;
            }
            return creditCardInfo;
        }
    }
}
