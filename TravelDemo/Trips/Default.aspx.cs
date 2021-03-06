﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelDemo.Trips
{
  public partial class Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    // The return type can be changed to IEnumerable, however to support
    // paging and sorting, the following parameters must be added:
    //     int maximumRows
    //     int startRowIndex
    //     out int totalRowCount
    //     string sortByExpression
    public async Task<IEnumerable<Models.Trip>> myGrid_GetData()
    {

      var ctx = new Models.TripContext();
      return await ctx.Trips.OrderBy(t => t.DepartureDateTimeUtc).ToListAsync();

    }
  }
}