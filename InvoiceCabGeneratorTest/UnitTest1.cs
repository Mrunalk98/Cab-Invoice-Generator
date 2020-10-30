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

        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }

        [Test]
        public void GivenRidesShouldReturnTotalNoOfRides_TotalFare_AvgFarePerRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary.NO_OF_RIDES, summary.NO_OF_RIDES);
            Assert.AreEqual(expectedSummary.TOTAL_FARE, summary.TOTAL_FARE);
            Assert.AreEqual(expectedSummary.AVERAGE_FARE, summary.AVERAGE_FARE);
        }

        [Test]
        public void GivenUserIdShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            invoiceGenerator.AddRides("1", rides);

            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("1");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }

        [Test]
        public void GivenRideTypeShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary normal = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedNormal = new InvoiceSummary(2, 30.0);


            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] premiumRides = { new Ride(3.0, 10), new Ride(2.0, 1) };

            InvoiceSummary premium = invoiceGenerator.CalculateFare(premiumRides);
            InvoiceSummary expectedPremium = new InvoiceSummary(2, 97.0);

            Assert.AreEqual(expectedNormal, normal);
            Assert.AreEqual(expectedPremium, premium);
        }

    }
}