using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI;
using Splat;

namespace ReactiveUIResearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Locator.CurrentMutable.Register(() => new SearchView(), typeof(IViewFor<AppViewModel>));
            Locator.CurrentMutable.Register(() => new RandomListView(), typeof(IViewFor<RandomListViewModel>));

            host.ViewModel = new RandomListViewModel();
        }

    }

    // Create a simple model class to store our Flickr results - since we will 
    // never update the properties once we create the object, we don't have to
    // use ReactiveObject, just good-old auto-properties.
    public class FlickrPhoto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

}
