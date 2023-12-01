
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SyncfusionDocumentation_Personal.DataBinding
{
    public class INotifyPropertyBase :ComponentBase
    {
        protected ObservableCollection<DataOrder> observableData { get; set; }
        protected int uniqueId;

        protected override void OnInitialized()
        {
            observableData = new ObservableCollection<DataOrder>(Enumerable.Range(1, 5).Select(x => new DataOrder()
            {
                OrderID = 10000 + x,
                CustomerName = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }));
        }

        protected void UpdateRecord()
        {
            if (observableData.Count() != 0)
            {
                var name = observableData.First();
                name.CustomerName = "Record Updated";
            }
        }

        public class DataOrder : INotifyPropertyChanged
        {
            public int OrderID { get; set; }
            protected string customerID { get; set; }
            public string CustomerName
            {
                get { return customerID; }
                set
                {
                    this.customerID = value;
                    NotifyPropertyChanged("CustomerID");
                }
            }
            public DateTime OrderDate { get; set; }
            public double Freight { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
