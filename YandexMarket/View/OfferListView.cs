using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using YandexMarket.Model;

namespace YandexMarket.View
{
    public class OfferListView : ListView
    {
        public OfferListView(Context context) : base(context)
        {
        }

        public void SetOffers(List<Offer> offers)
        {
            var adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleListItem1,
                offers.Select(offer => offer.Id).ToArray());
            Adapter = adapter;
        }
    }
}