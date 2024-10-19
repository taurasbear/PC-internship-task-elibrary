namespace PCElibrary.Domain.Services
{
    using PCElibrary.Domain.Entities;
    using PCElibrary.Domain.Enums;

    public static class ReservationCalculator
    {
        private const decimal PhysicalBookPricePerDay = 2m;

        private const decimal AudioBookPricePerDay = 3m;

        private const decimal DiscountPercentage1 = 20m;

        private const int DiscountDayCount1 = 10;

        private const decimal DiscountPercentage2 = 10m;

        private const int DiscountDayCount2 = 3;

        private const decimal ServiceFee = 3m;

        private const decimal QuickPickUpFee = 5m;

        public static decimal CalculatePrice(BookReservation bookReservation)
        {
            decimal price = 0;
            if (bookReservation.BookType.Format == BookFormat.Physical)
            {
                price += PhysicalBookPricePerDay * bookReservation.Days;
            }
            else if (bookReservation.BookType.Format == BookFormat.Audio)
            {
                price += AudioBookPricePerDay * bookReservation.Days;
            }

            if (bookReservation.Days > DiscountDayCount1)
            {
                price = price * (100 - DiscountPercentage1);
            }
            else if (bookReservation.Days > DiscountDayCount2)
            {
                price = price * (100 - DiscountPercentage2);
            }

            price += ServiceFee;

            if (bookReservation.QuickPickUp)
            {
                price += QuickPickUpFee;
            }

            return price;
        }
    }
}
