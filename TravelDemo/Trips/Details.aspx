<%@ Page Language="C#" Title="Trip Details" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="TravelDemo.Trips.Details" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

  <asp:FormView runat="server" ID="myForm" 
    ItemType="TravelDemo.Models.Trip" DataKeyNames="Id"
   OnModeChanging="myForm_ModeChanging"
    OnItemInserting="myForm_ItemInserting"
    OnItemUpdating="myForm_ItemUpdating">
    <ItemTemplate>
      <fieldset>
        <legend><%#: Item.DestinationName %> (<%#: Item.Id %>)</legend>

        <dl>

          <dt>Destination:</dt>
          <dd><%#: Item.DestinationName %></dd>

          <dt>Departure Date:</dt>
          <dd><%#: Item.DepartureDateTimeUtc.ToLocalTime().Date %></dd>

          <dt>Return Date:</dt>
          <dd><%#: Item.ReturnDateTimeUtc.ToLocalTime().Date %></dd>

        </dl>

        <p>
          <asp:Button runat="server" ID="edit" Text="Edit" CommandName="Edit" />
        </p>

      </fieldset>
    </ItemTemplate>

    <InsertItemTemplate>
      <fieldset>

        <legend>Add a New Trip</legend>

        <dl>

          <dt>Destination:</dt>
          <dd><asp:TextBox runat="server" ID="insert_destinationname" Text="<%#: BindItem.DestinationName %>"></asp:TextBox></dd>

          <dt>Departure Date:</dt>
          <dd><asp:TextBox runat="server" ID="insert_departuredatetimeutc" TextMode="Date" Text="<%#: BindItem.DepartureDateTimeUtc %>"></asp:TextBox></dd>

          <dt>Return Date:</dt>
          <dd><asp:TextBox runat="server" ID="insert_returndatetimeutc" TextMode="Date" Text="<%#: BindItem.ReturnDateTimeUtc %>"></asp:TextBox></dd>

        </dl>

        <p>
          <asp:Button runat="server" ID="save" Text="Save" CommandName="Insert" />
          <asp:Button runat="server" ID="cancel" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
        </p>

      </fieldset>
    </InsertItemTemplate>

    <EditItemTemplate>
      <fieldset>

        <legend>Edit Trip "<%#: Item.DestinationName %>"</legend>

        <dl>

          <dt>Destination:</dt>
          <dd><asp:TextBox runat="server" ID="update_destinationname" Text="<%#: BindItem.DestinationName %>"></asp:TextBox></dd>

          <dt>Departure Date:</dt>
          <dd><asp:TextBox runat="server" ID="update_departuredatetimeutc" TextMode="Date" Text='<%#: Item.DepartureDateTimeUtc.ToString("yyyy-MM-dd") %>'></asp:TextBox></dd>

          <dt>Return Date:</dt>
          <dd><asp:TextBox runat="server" ID="update_returndatetimeutc" TextMode="Date" Text='<%#: Item.ReturnDateTimeUtc.ToString("yyyy-MM-dd") %>'></asp:TextBox></dd>

        </dl>

        <p>
          <asp:Button runat="server" ID="save" Text="Save" CommandName="Update" />
          <asp:Button runat="server" ID="cancel" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
        </p>

      </fieldset>
    </EditItemTemplate>

  </asp:FormView>


</asp:Content>