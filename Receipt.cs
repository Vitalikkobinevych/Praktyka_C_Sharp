using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Receipt
{

    class Receipt
    {
        private string[] mas_bank = new[] { "privatbank", "universal_bank" };
        private string[] mas_payment = new[] { "monthly", "yearly" };

        private string _ID;
        private string _receipt_name;
        private string _receipt_iban;
        private string _bank;
        private string _payment_type;
        private string _amount;
        private string _payment_datetime;

        public string ID
        {
            get => _ID;
            set { _ID = Validation.Number(value); }
        }

        public string receipt_name
        {
            get => _receipt_name;
            set { _receipt_name = Validation.String(value); }
        }

        public string receipt_iban
        {
            get => _receipt_iban;
            set { _receipt_iban = Validation.Number(value); }
        }

        public string bank
        {
            get => _bank;
            set { _bank = Validation.ValidateType(value, mas_bank); }
        }

        public string payment_type
        {
            get => _payment_type;
            set { _payment_type = Validation.ValidateType(value, mas_payment); }
        }

        public string amount
        {
            get => _amount;
            set
            {
                _amount = Validation.Number(value);
                _amount = Validation.ValidatePrice(value);
            }
        }

        public string payment_datetime
        {
            get => _payment_datetime;
            set { _payment_datetime = Validation.ValidateDate(value); }
        }

        public string print()
        {
            return ($"ID: {ID} \nreceipt name: {receipt_name} \nreceipt iban: {receipt_iban} \nbank: {bank} \npayment type: {payment_type} " +
                $"\namount: {amount} \npayment datetime: {payment_datetime}\n");
        }

        public void input()
        {
            Console.Write("ID: ");
            ID = Console.ReadLine();
            Console.Write("Receipt name: ");
            receipt_name = Console.ReadLine();
            Console.Write("Receipt iban: ");
            receipt_iban = Console.ReadLine();
            Console.Write("Bank: ");
            bank = Console.ReadLine();
            Console.Write("Payment type: ");
            payment_type = Console.ReadLine();
            Console.Write("Amount: ");
            amount = Console.ReadLine();
            Console.Write("Payment datetime: ");
            payment_datetime = Console.ReadLine();
        }
    }
}