using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace PrjDay3.Models
{
    public class CarContext : DbContext
    { 
        public CarContext():base("name=efVehicles")
        {

        }
        public DbSet<Car> cars { get; set; }
    }
}