using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using System.Xml;
using YandexMarket.Model;

namespace YandexMarket
{
    [Activity(Label = "OfferActivity")]
    public class OfferActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_offer);

            var offerJson = Intent.GetStringExtra("offer");
            var offer = JsonConvert.DeserializeObject<Offer>(offerJson);

            var offerDetailsView = FindViewById<TextView>(Resource.Id.offerDetailsTextView);
            offerDetailsView.Text = JsonConvert.SerializeObject(offer, Newtonsoft.Json.Formatting.Indented);
        }
    }
}