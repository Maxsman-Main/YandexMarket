using System.Collections.Generic;
using System.Threading.Tasks;

namespace YandexMarket.Model
{
    public class OfferModel
    {
        private readonly OfferRequestService _offerRequestService;

        public OfferModel(OfferRequestService offerRequestService)
        {
            _offerRequestService = offerRequestService;
        }

        public async Task<List<Offer>> GetOffers(string url)
        {
            return await _offerRequestService.GetOffersAsync(url);
        }
    }
}