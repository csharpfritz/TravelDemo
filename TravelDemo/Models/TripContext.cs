using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TravelDemo.Models
{
  public class TripContext : DbContext
  {

    public DbSet<Trip> Trips { get; set; }

  }
}