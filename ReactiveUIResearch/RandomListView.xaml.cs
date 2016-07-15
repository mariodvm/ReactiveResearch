using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using ReactiveUIResearch.Annotations;

namespace ReactiveUIResearch
{
    /// <summary>
    /// Interaction logic for RandomListView.xaml
    /// </summary>
    public partial class RandomListView : UserControl, IViewFor<RandomListViewModel>, INotifyPropertyChanged
    {
        public RandomListView()
        {
            InitializeComponent();

            //this.OneWayBind(ViewModel, vm => vm.RandomList, v => v.lb.ItemsSource);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set
            {
                ViewModel = (RandomListViewModel) value;
                OnPropertyChanged();
            }
        }

        public RandomListViewModel ViewModel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
