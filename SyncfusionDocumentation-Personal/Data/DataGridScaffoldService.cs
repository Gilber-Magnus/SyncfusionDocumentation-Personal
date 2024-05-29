using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncfusionDocumentation_Personal.Data;

	namespace SyncfusionDocumentation_Personal.Data
	{
	   public class DataGridScaffoldService
	   {
			 OrderDetailsDbContext db=new OrderDetailsDbContext();
			 
			//To Get all Order details   
			public DbSet<Order> GetAllOrder()
			{
				try
				{
					return db.Orders;
				}
				catch
				{
					throw;
				}
			}
	    }
   
}