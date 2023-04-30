using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public class OfferService : IOfferService
    {
        private readonly List<Offers> _offers;

        public OfferService()
        {
            _offers = new List<Offers>();
        }

        public Offers GetOfferById(int offerId)
        {
            return _offers.FirstOrDefault(offer => offer.OfferID == offerId);
        }

        public List<Offers> GetAllOffers()
        {
            return _offers;
        }

        public void CreateOffer(Offers offer)
        {
            offer.OfferID = GenerateOfferId();
            _offers.Add(offer);
        }

        public void UpdateOffer(Offers offer)
        {
            var existingOffer = _offers.FirstOrDefault(o => o.OfferID == offer.OfferID);
            if (existingOffer != null)
            {
                existingOffer.StartDate = offer.StartDate;
                existingOffer.EndDate = offer.EndDate;
                existingOffer.Type = offer.Type;
                existingOffer.Value = offer.Value;
                existingOffer.OfferDescription = offer.OfferDescription;
                existingOffer.CreatedByUserID = offer.CreatedByUserID;
            }
        }

        public void DeleteOffer(int offerId)
        {
            var offer = _offers.FirstOrDefault(o => o.OfferID == offerId);
            if (offer != null)
            {
                _offers.Remove(offer);
            }
        }

        private int GenerateOfferId()
        {
            // Generate a unique offer ID based on your requirements
            // This is just a placeholder implementation
            return _offers.Count + 1;
        }
    }
}
