using System;

namespace Online_Utility_Bill_System
{
    internal class Customer
    {
        public int CustomerID;
        public string CustomerName;

       
        public static double GetServiceCharge()
        {
            return 50.0; 
        }

       
        public double TotalUsage(params int[] readings)
        {
            double total = 0;
            foreach (int unit in readings)
            {
                total += unit * 6.5; 
            }
            return total;
        }

       
        public void CalculateBill(out double total, out double tax, out double netPayable, params int[] readings)
        {
            total = TotalUsage(readings);
            tax = total * 0.10; 
            netPayable = GetServiceCharge() + total + tax;
        }
    }
}
