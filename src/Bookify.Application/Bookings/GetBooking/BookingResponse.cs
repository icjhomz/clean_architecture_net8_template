using System.Text.Json.Serialization;

namespace Bookify.Application.Bookings.GetBooking;

public sealed class BookingResponse
{
    public Guid Id { get; init; }
    public Guid ApartmentId { get; init; }
    public Guid UserId { get; init; }
    public int Status { get; init; }
    public decimal PriceAmount { get; init; }
    public string PriceCurrency { get; init; }
    public decimal CleaningFeeAmount { get; init; }
    public string CleaningFeeCurrency { get; init; }
    public decimal AmenitiesUpChargeAmount { get; init; }
    public string AmenitiesUpChargeCurrency { get; init; }
    public decimal TotalPriceAmount { get; init; }
    public string TotalPriceCurrency { get; init; }
    public DateOnly DurationStart { get; init; }
    public DateOnly DurationEnd { get; init; }
    public DateTime CreatedOnUtc { get; init; }

    public BookingResponse(Guid id, Guid apartmentId, Guid userId, int status, decimal priceAmount, string priceCurrency,
        decimal cleaningFeeAmount, string cleaningFeeCurrency, decimal amenitiesUpChargeAmount, string amenitiesUpChargeCurrency,
        decimal totalPriceAmount, string totalPriceCurrency, DateOnly durationStart, DateOnly durationEnd, DateTime createdOnUtc)
    {
        Id = id;
        ApartmentId = apartmentId;
        UserId = userId;
        Status = status;
        PriceAmount = priceAmount;
        PriceCurrency = priceCurrency;
        CleaningFeeAmount = cleaningFeeAmount;
        CleaningFeeCurrency = cleaningFeeCurrency;
        AmenitiesUpChargeAmount = amenitiesUpChargeAmount;
        AmenitiesUpChargeCurrency = amenitiesUpChargeCurrency;
        TotalPriceAmount = totalPriceAmount;
        TotalPriceCurrency = totalPriceCurrency;
        DurationStart = durationStart;
        DurationEnd = durationEnd;
        CreatedOnUtc = createdOnUtc;
    }
}
