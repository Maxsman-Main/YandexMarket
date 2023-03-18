using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using System.Threading.Tasks;
using YandexMarket.Model;
using YandexMarket.View;
using Newtonsoft.Json;

namespace YandexMarket.Controller
{
    public class OfferController
    {
        private readonly OfferModel _offerModel;
        private readonly OfferListView _offerView;
        private readonly Context _context;
        
        private List<Offer> _offers;

        public OfferController(OfferModel offerModel, OfferListView offerView, Context context)
        {
            _offerModel = offerModel;
            _offerView = offerView;
            _context = context;
            SubscribeOnClick();
        }

        public async Task LoadAndShowOffers(string link)
        {
            _offers = await _offerModel.GetOffers(link);
            _offerView.SetOffers(_offers);
        }

        public void SubscribeOnClick()
        {
            _offerView.ItemClick += OnItemClick;
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var offer = _offers[e.Position];

            var intent = new Intent(_context, typeof(OfferActivity));
            intent.PutExtra("offer", JsonConvert.SerializeObject(offer));
            _context.StartActivity(intent);
        }
    }
}