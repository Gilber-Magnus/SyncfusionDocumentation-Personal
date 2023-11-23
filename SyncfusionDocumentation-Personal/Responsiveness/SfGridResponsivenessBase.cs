using Microsoft.AspNetCore.Components;

namespace SyncfusionDocumentation_Personal.Responsiveness
{
    public class SfGridResponsivenessBase : ComponentBase
    {

        public class OrderData
        {
            public static List<OrderData> Orders = new List<OrderData>();
            public OrderData()
            {

            }
            public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
            {
                this.OrderID = OrderID;
                this.CustomerID = CustomerID;
                this.OrderDate = OrderDate;
                this.Freight = Freight;
            }

            public static List<OrderData> GetAllRecords()
            {
                if (Orders.Count() == 0)
                {
                    int code = 10;
                    for (int i = 1; i < 2; i++)
                    {
                        Orders.Add(new OrderData(10248, "VINET", new DateTime(1996, 07, 06), 32.38));
                        Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                        Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 06), 65.83));
                        Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 06), 45.78));
                        Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                        Orders.Add(new OrderData(10253, "HANAR", new DateTime(1996, 07, 06), 103.45));
                        Orders.Add(new OrderData(10254, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                        Orders.Add(new OrderData(10255, "RICSU", new DateTime(1996, 07, 06), 112.48));
                        Orders.Add(new OrderData(10256, "WELLI", new DateTime(1996, 07, 06), 33.45));
                        code += 5;
                    }
                }
                return Orders;
            }

            public int? OrderID { get; set; }
            public string CustomerID { get; set; }
            public DateTime? OrderDate { get; set; }
            public double? Freight { get; set; }
        }

    }
}
