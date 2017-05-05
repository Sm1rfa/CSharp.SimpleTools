using System;
using System.Windows;
using System.Windows.Controls;
using Esri.ArcGISRuntime.Controls;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Layers;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using Esri.ArcGISRuntime.WebMap;

namespace SimpleTools.View
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {
        // Maps documentation https://developers.arcgis.com/net/latest/wpf/sample-code/accessloadstatus.htm
        // for webmaps https://developers.arcgis.com/net/10-2/sample-code/CreateWebMap/
        // for search feature https://developers.arcgis.com/net/10-2/desktop/guide/add-geocoding-to-your-app.htm !!!
        //private string[] titles = new string[]
        //{
        //    "Topo",
        //    "Streets",
        //    "Imagery",
        //    "Ocean"
        //};

        public MapView()
        {
            InitializeComponent();
            //this.Initialize();
        }

        //private void Initialize()
        //{
        //    // Assign a new map to the MapView
        //    MyMapView.Map = new Map();

        //    // Set basemap titles as a items source
        //    basemapChooser.ItemsSource = titles;

        //    // Show the first basemap in the list
        //    basemapChooser.SelectedIndex = 0;
        //}

        //private void OnBasemapChooserSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var selectedBasemap = e.AddedItems[0].ToString();

        //    switch (selectedBasemap)
        //    {
        //        case "Topo":
        //            // Set the basemap to Topographic
        //            MyMapView.Map.Basemap = Basemap.CreateTopographic();
        //            break;
        //        case "Streets":
        //            // Set the basemap to Streets
        //            MyMapView.Map.Basemap = Basemap.CreateStreets();
        //            break;
        //        case "Imagery":
        //            // Set the basemap to Imagery
        //            MyMapView.Map.Basemap = Basemap.CreateImagery();
        //            break;
        //        case "Ocean":
        //            // Set the basemap to Oceans
        //            MyMapView.Map.Basemap = Basemap.CreateOceans();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private async void FindAddressButton_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("http://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer");
            var token = String.Empty;
            var locator = new OnlineLocatorTask(uri, token);

            var findParams = new OnlineLocatorFindParameters(AddressTextBox.Text);
            findParams.OutSpatialReference = MyMapView.SpatialReference;
            //findParams.SourceCountry = "BG";

            var results = await locator.FindAsync(findParams, new System.Threading.CancellationToken());

            if (results.Count > 0)
            {
                var firstMatch = results[0].Feature;
                var matchLocation = firstMatch.Geometry as MapPoint;
                var matchExtent = new Envelope(matchLocation.X - 100,
                    matchLocation.Y - 100,
                    matchLocation.X + 100,
                    matchLocation.Y + 100);
                var matchSym = new PictureMarkerSymbol();
                var pictureUri = new Uri("http://static.arcgis.com/images/Symbols/Basic/GreenStickpin.png");
                await matchSym.SetSourceAsync(pictureUri);
                var matchGraphic = new Graphic(matchLocation, matchSym);
                var graphicsLayer = MyMap.Layers["GeocodeResults"] as GraphicsLayer;
                graphicsLayer.Graphics.Add(matchGraphic);
                await MyMapView.SetViewAsync(matchExtent);
            }
        }
    }
}
