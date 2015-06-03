using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
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

        }

      }

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
      //BindTrip(myForm.DataKey.Value.ToString());

    }

    protected void myForm_ModeChanging(object sender, FormViewModeEventArgs e)
    {
      if (e.NewMode == FormViewMode.Edit)
      {
        myForm.ChangeMode(FormViewMode.Edit);
        //BindTrip(myForm.DataKey.Value.ToString());
      }
    }

    // The id parameter should match the DataKeyNames value set on the control
    // or be decorated with a value provider attribute, e.g. [QueryString]int id
    public TravelDemo.Models.Trip myForm_GetItem([QueryString]string id)
    {
      return GetTripFor(id);
    }

    public void myForm_InsertItem()
    {
      var item = new TravelDemo.Models.Trip() {
        Id=Guid.NewGuid()
      };
      TryUpdateModel(item);
      if (ModelState.IsValid)
      {
        // Save changes here
        _Context.Trips.Add(item);
        _Context.SaveChanges();
        Response.Redirect("~/Trips/Details?id=" + item.Id);
      }
    }

    // The id parameter name should match the DataKeyNames value set on the control
    public void myForm_UpdateItem(string id)
    {

      var item = GetTripFor(id);
      // Load the item here, e.g. item = MyDataLayer.Find(id);
      if (item == null)
      {
        // The item wasn't found
        ModelState.AddModelError("", String.Format("Trip with id {0} was not found", id));
        return;
      }
      TryUpdateModel(item);
      if (ModelState.IsValid)
      {
        // Save changes here, e.g. MyDataLayer.SaveChanges();
        _Context.SaveChanges();

      }
    }
  }
}