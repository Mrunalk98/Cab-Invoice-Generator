using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int NO_OF_RIDES;
        private double TOTAL_FARE;
        private double AVERAGE_FARE;

        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.NO_OF_RIDES = numberOfRides;
            this.TOTAL_FARE = totalFare;
            this.AVERAGE_FARE = this.TOTAL_FARE / this.NO_OF_RIDES;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is InvoiceSummary))
                return false;
            InvoiceSummary invoiceObj = (InvoiceSummary)obj;
            return this.NO_OF_RIDES == invoiceObj.NO_OF_RIDES && this.TOTAL_FARE == invoiceObj.TOTAL_FARE && this.AVERAGE_FARE == invoiceObj.AVERAGE_FARE;
        }

        public override int GetHashCode()
        {
            return this.NO_OF_RIDES.GetHashCode() ^ this.TOTAL_FARE.GetHashCode() ^ this.AVERAGE_FARE.GetHashCode();
        }
    }
}
