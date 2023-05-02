using car_system.Controllers.Data;
using car_system.Models;
using car_system.Models.Entities;
using System;

namespace car_system.Controllers.Services
{
    public class OfferService : IOfferService
    {
        private readonly ApplicationDbContext _dbContext;

        public OfferService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Offers GetOfferById(int id)
        {
            return _dbContext.Offers.Find(id);
        }

        public List<Offers> GetAllOffers()
        {
            return _dbContext.Offers.ToList();
        }

        public void CreateOffer(CreateOfferView offerView)
        {
            var offer = new Offers
            {
                StartDate = offerView.StartDate,
                EndDate = offerView.EndDate,
                Value = offerView.Value,
                OfferDescription = offerView.OfferDescription,
                CreatedByUserID = offerView.CreatedByUserID
            };

            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }

        public void UpdateOffer(Offers offer)
        {
            _dbContext.Offers.Update(offer);
            _dbContext.SaveChanges();
        }

        public void DeleteOffer(int id)
        {
            var offer = _dbContext.Offers.Find(id);

            if (offer != null)
            {
                _dbContext.Offers.Remove(offer);
                _dbContext.SaveChanges();
            }
        }

        Offers IOfferService.GetOfferById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
