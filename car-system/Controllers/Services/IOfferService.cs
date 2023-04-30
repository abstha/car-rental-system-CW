using car_system.Models;
using car_system.Models.Entities;
using System;

namespace car_system.Controllers.Services
{
    public interface IOfferService
    {
        Offers GetOfferById(int offerId);
        List<Offers> GetAllOffers();
        void CreateOffer(AddOfferView offerView);
        void UpdateOffer(Offers offer);
        void DeleteOffer(int offerId);
    }
}
