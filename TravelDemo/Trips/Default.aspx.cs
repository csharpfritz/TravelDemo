using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelDemo.Trips
{
  public partial class Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

      if (!Page.IsPostBack)
      {
        BindGrid();
      }

    }

    private void BindGrid()
    {
      var ctx = new Models.TripContext();
      myGrid.DataSource = ctx.Trips.AsEnumerable().OrderBy(t => t.DepartureDateTimeUtc);
      myGrid.DataBind();
    }
  }
}