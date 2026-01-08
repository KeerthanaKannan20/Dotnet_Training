using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

namespace ElectricityBill

{

    public class ElectricityBill

    {

        private string consumerNumber;

        private string consumerName;

        public string ConsumerNumber

        {

            get { return consumerNumber; }

            set

            {

                if (value.Length != 7 || !value.StartsWith("EB") || !int.TryParse(value.Substring(2), out _))

                {

                    throw new FormatException("Invalid Consumer Number");

                }

                consumerNumber = value;

            }

        }

        public string ConsumerName

        {

            get { return consumerName; }

            set

            {

                consumerName = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;

            }

        }

        public int UnitsConsumed { get; set; }

        public double BillAmount { get; set; }

        public ElectricityBill()

        {

            consumerNumber = "";

            consumerName = "";

            UnitsConsumed = 0;

            BillAmount = 0;

        }

        public ElectricityBill(string number, string name, int units)

        {

            ConsumerNumber = number;

            ConsumerName = name;

            UnitsConsumed = units;

            BillAmount = 0;

        }

    }

}
