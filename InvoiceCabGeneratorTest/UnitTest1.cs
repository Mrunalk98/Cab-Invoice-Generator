using NUnit.Framework;
using CabInvoiceGenerator;

namespace InvoiceCabGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        [Test]
        public void GivenDistanceAndTimeReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            double actual = invoiceGenerator.CalculateRideFare(distance, time);
            double expected = 25;

            Assert.AreEqual(expected, actual);
        }

    }
}