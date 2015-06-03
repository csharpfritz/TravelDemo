<%@ Page Language="C#" Async="true" Title="Trip Details" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="TravelDemo.Trips.Details" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

  <asp:FormView runat="server" ID="myForm" 
    ItemType="TravelDemo.Models.Trip" DataKeyNames="Id"
    SelectMethod="myForm_GetItem"
    InsertMethod="myForm_InsertItem"
    UpdateMethod="myForm_UpdateItem">
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
          <dd><asp:TextBox runat="server" ID="DestinationName" Text="<%#: BindItem.DestinationName %>"></asp:TextBox></dd>

          <dt>Departure Date:</dt>
          <dd><asp:TextBox runat="server" ID="DepartureDateTimeUtc" TextMode="Date" Text="<%#: BindItem.DepartureDateTimeUtc %>"></asp:TextBox></dd>

          <dt>Return Date:</dt>
          <dd><asp:TextBox runat="server" ID="ReturnDateTimeUtc" TextMode="Date" Text="<%#: BindItem.ReturnDateTimeUtc %>"></asp:TextBox></dd>

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
          <dd><asp:TextBox runat="server" ID="DestinationName" Text="<%#: BindItem.DestinationName %>"></asp:TextBox></dd>

          <dt>Departure Date:</dt>
          <dd><asp:TextBox runat="server" ID="DepartureDateTimeUtc" TextMode="Date" Text='<%#: Bind("DepartureDateTimeUtc", "{0:yyyy-MM-dd}") %>'></asp:TextBox></dd>

          <dt>Return Date:</dt>
          <dd><asp:TextBox runat="server" ID="ReturnDateTimeUtc" TextMode="Date" Text='<%#: Bind("ReturnDateTimeUtc", "{0:yyyy-MM-dd}") %>'></asp:TextBox></dd>

        </dl>

        <p>
          <asp:Button runat="server" ID="save" Text="Save" CommandName="Update" />
          <asp:Button runat="server" ID="cancel" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
        </p>

      </fieldset>
    </EditItemTemplate>

  </asp:FormView>


</asp:Content>