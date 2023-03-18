using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using YandexMarket.Controller;
using YandexMarket.Model;
using YandexMarket.View;

namespace YandexMarket
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const string link = "http://partner.market.yandex.ru/pages/help/YML.xml";

        private OfferModel _offerModel;
        private OfferListView _offerListView;
        private OfferController _offerController;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _offerListView = new OfferListView(this);
            SetContentView(_offerListView);

            var offerRequestService = new OfferRequestService();
            _offerModel = new OfferModel(offerRequestService);
        
            _offerController = new OfferController(_offerModel, _offerListView, this);
            LoadOffers(link);
        }

        private async void LoadOffers(string link)
        {
            await _offerController.LoadAndShowOffers(link);
        }
    }
}