using System;
using System.Windows;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Layers;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace SimpleTools.ViewModel
{
    public class MapViewModel : ViewModelBase
    {
        private string addressBox;

        public RelayCommand FindAddressCommand { get; set; }

        public MapViewModel()
        {
            this.FindAddressCommand = new RelayCommand(this.FindAddress);
        }

        public string AddressBox
        {
            get
            {
                return this.addressBox;
            }

            set
            {
                this.addressBox = value;
                this.RaisePropertyChanged();
            }
        }

        private async void FindAddress()
        {
            //var uri = new Uri("http://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer");
            //var token = String.Empty;
            //var locator = new OnlineLocatorTask(uri, token);

            //var findParams = new OnlineLocatorFindParameters(this.AddressBox);
            //findParams.OutSpatialReference = MyMapView.SpatialReference;
            ////findParams.SourceCountry = "BG";

            //var results = await locator.FindAsync(findParams, new System.Threading.CancellationToken());

            //if (results.Count > 0)
            //{
            //    var firstMatch = results[0].Feature;
            //    var matchLocation = firstMatch.Geometry as MapPoint;
            //    var matchExtent = new Envelope(matchLocation.X - 100,
            //                   matchLocation.Y - 100,
            //                   matchLocation.X + 100,
            //                   matchLocation.Y + 100);
            //    var matchSym = new PictureMarkerSymbol();
            //    var pictureUri = new Uri("http://static.arcgis.com/images/Symbols/Basic/GreenStickpin.png");
            //    await matchSym.SetSourceAsync(pictureUri);
            //    var matchGraphic = new Graphic(matchLocation, matchSym);
            //    var graphicsLayer = MyMap.Layers["GeocodeResults"] as GraphicsLayer;
            //    graphicsLayer.Graphics.Add(matchGraphic);
            //    await MyMapView.SetViewAsync(matchExtent);
            //}
        }
    }
}
