using System.Xml.Linq;

namespace HW_4._Operator_overload
{
    public class CreditCard
    {
        private string _cardNumber;
        private decimal _balance;
        private string _cvcCode;

        public string CardNumber
        {
            get { return _cardNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Card number cannot be empty.");
                if (!value.All(char.IsDigit))
                    throw new ArgumentException("Card number must contain only digits.");
                if (value.Length != 16)
                    throw new ArgumentException("Card number must be 16 digits long.");

                _cardNumber = value;
            }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                _balance = value;
            }
        }

        public string CvcCode
        {
            get { return _cvcCode; }
            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("CVC code must be 3 digits");
                _cvcCode = value;
            }
        }

        public CreditCard(string cardNumber, decimal balance, string cvcCode)
        {
            CardNumber = cardNumber;
            Balance = balance;
            CvcCode = cvcCode;
        }

        public static CreditCard operator +(CreditCard card, decimal amount)
        {
            card.Balance += amount;
            return card;
        }
        public static CreditCard operator -(CreditCard card, decimal amount)
        {
            if (card.Balance < amount)
                throw new InvalidOperationException("Not enough funds");

            card.Balance -= amount;
            return card;
        }
        public static bool operator ==(CreditCard card1, CreditCard card2) => card1.CvcCode == card2.CvcCode;
        public static bool operator !=(CreditCard card1, CreditCard card2) => !(card1 == card2);
        public static bool operator >(CreditCard card1, CreditCard card2) => card1.Balance > card2.Balance;

        public static bool operator <(CreditCard card1, CreditCard card2) => card1.Balance < card2.Balance;
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is CreditCard))
                return false;

            CreditCard other = (CreditCard)obj;
            return this.CvcCode == other.CvcCode;
        }
        public override int GetHashCode() => HashCode.Combine(CardNumber, Balance, CvcCode);
        public void PrintCardInfo() => Console.WriteLine($"{CardNumber} - Balance: {Balance:C} - CvcCode: {CvcCode}");
    }

}
