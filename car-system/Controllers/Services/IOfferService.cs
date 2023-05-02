using car_system.Models;
using car_system.Models.Entities;
using System;

namespace car_system.Controllers.Services
{
    public interface IOfferService
    {
        Offers GetOfferById(int id);
        List<Offers> GetAllOffers();
        void CreateOffer(CreateOfferView offerView);
        void UpdateOffer(Offers offer);
        void DeleteOffer(int id);
    }
}
