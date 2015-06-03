using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

    private async Task<Models.Trip> GetTripFor(string id)
    {

      var tripId = Guid.Parse(id);
      return await _Context.Trips.FirstOrDefaultAsync(t => t.Id == tripId);

    }

    // The id parameter should match the DataKeyNames value set on the control
    // or be decorated with a value provider attribute, e.g. [QueryString]int id
    public async Task<TravelDemo.Models.Trip> myForm_GetItem([QueryString]string id)
    {
      return await GetTripFor(id);
    }

    public async Task myForm_InsertItem()
    {
      var item = new TravelDemo.Models.Trip() {
        Id=Guid.NewGuid()
      };
      TryUpdateModel(item);
      if (ModelState.IsValid)
      {
        // Save changes here
        _Context.Trips.Add(item);
        await _Context.SaveChangesAsync();
        Response.Redirect("~/Trips/Details?id=" + item.Id);
      }
    }

    // The id parameter name should match the DataKeyNames value set on the control
    public async Task myForm_UpdateItem(string id)
    {

      var item = await GetTripFor(id);
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
        await _Context.SaveChangesAsync();

      }
    }
  }
}