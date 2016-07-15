using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using ReactiveUI;

namespace ReactiveUIResearch
{
    public class RandomListViewModel : ReactiveObject
    {
        private Random _random;
        public RandomListViewModel()
        {
            _random = new Random();

            _Producer = ProduceRandomStrings().ToObservable();

            this._Producer
                .Throttle(TimeSpan.FromMilliseconds(800), RxApp.MainThreadScheduler)
                .ObserveOnDispatcher()
                .Subscribe(x => RandomList.Add(x));
        }

        private IEnumerable<string> ProduceRandomStrings()
        {
            while (true)
            {
                yield return _random.Next(1000) + "";
            }
        }

        public ObservableCollection<string> RandomList { get; } = new ObservableCollection<string>();


        private readonly IObservable<string> _Producer;
        public IEnumerable<string> Producer => _Producer.ToEnumerable();
    }

}
