using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace SyncfusionDocumentation_Personal.DataBinding
{
    public class ICollectionBase : ComponentBase
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

        protected void AddRecord()
        {
            observableData.Add(new DataOrder() { OrderID = 10010 + ++uniqueId, CustomerName = "VINET", Freight = 30.35, OrderDate = new DateTime(1991, 05, 15) });
        }

        protected void DeleteRecord()
        {
            if (observableData.Count() != 0)
            {
                observableData.Remove(observableData.First());
            }
        }

        public class DataOrder
        {
            public int OrderID { get; set; }
            public string CustomerName { get; set; }
            public DateTime OrderDate { get; set; }
            public double Freight { get; set; }
        }

    }
}
