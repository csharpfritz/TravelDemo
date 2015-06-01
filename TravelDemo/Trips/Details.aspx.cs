using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelDemo.Trips
{
  public partial class Details : System.Web.UI.Page
  {

    private Models.TripContext _Context;

    protected override void OnInit(EventArgs e)
    {
      _Context = new Models.TripContext();
      base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

      if (!Page.IsPostBack)
      {

        var formMode = Request.QueryString["mode"] ?? "details";
        switch (formMode.ToLowerInvariant())
        {
          case "add":
            myForm.ChangeMode(FormViewMode.Insert);
            break;
          case "edit":
            myForm.ChangeMode(FormViewMode.Edit);
            break;
          default:
            myForm.ChangeMode(FormViewMode.ReadOnly);
            break;
        }

        if (myForm.CurrentMode != FormViewMode.Insert)
        {

          if (string.IsNullOrEmpty(Request.QueryString["id"]))
            Response.Redirect("~/Trips");

          BindTrip(Request.QueryString["id"]);
        }

      }

    }

    private void BindTrip(string id)
    {
      myForm.DataSource = new[] { GetTripFor(id) };
      myForm.DataBind();
    }

    private Models.Trip GetTripFor(string id)
    {

      var tripId = Guid.Parse(id);
      return _Context.Trips.FirstOrDefault(t => t.Id == tripId);

    }

    protected void myForm_ItemInserting(object sender, FormViewInsertEventArgs e)
    {

      var newTrip = new Models.Trip
      {
        Id = Guid.NewGuid(),
        DestinationName = e.Values["DestinationName"].ToString(),
        DepartureDateTimeUtc = Convert.ToDateTime(e.Values["DepartureDateTimeUtc"].ToString()),
        ReturnDateTimeUtc = Convert.ToDateTime(e.Values["ReturnDateTimeUtc"].ToString())
      };

      _Context.Trips.Add(newTrip);
      _Context.SaveChanges();

      Response.Redirect("~/Trips");

    }

    protected void myForm_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {

      var toUpdate = GetTripFor(myForm.DataKey.Value.ToString());

      toUpdate.DestinationName = e.NewValues["DestinationName"].ToString();
      toUpdate.DepartureDateTimeUtc = Convert.ToDateTime(((TextBox)myForm.FindControl("update_departuredatetimeutc")).Text);
      toUpdate.ReturnDateTimeUtc = Convert.ToDateTime(((TextBox)myForm.FindControl("update_returndatetimeutc")).Text);

      _Context.SaveChanges();
      myForm.ChangeMode(FormViewMode.ReadOnly);
      BindTrip(myForm.DataKey.Value.ToString());

    }

    //protected void myForm_ItemCommand(object sender, FormViewCommandEventArgs e)
    //{
    //  switch (e.CommandName.ToLowerInvariant())
    //  {
    //    case "insert":
    //      myForm.ChangeMode(FormViewMode.Insert);
    //      break;
    //    case "edit":
    //      myForm.ChangeMode(FormViewMode.Edit);
    //      BindTrip(myForm.DataKey.Value.ToString());
    //      break;
    //    case "save":
    //      myForm.ChangeMode(FormViewMode.Edit);
    //      break;
    //    default:
    //      myForm.ChangeMode(FormViewMode.ReadOnly);
    //      BindTrip(myForm.DataKey.Value.ToString());
    //      break;
    //  }

   // }

    protected void myForm_ModeChanging(object sender, FormViewModeEventArgs e)
    {
      if (e.NewMode == FormViewMode.Edit)
      {
        myForm.ChangeMode(FormViewMode.Edit);
        BindTrip(myForm.DataKey.Value.ToString());
      }
    }
  }
}