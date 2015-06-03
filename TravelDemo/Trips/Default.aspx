<%@ Page Language="C#" Async="true" Title="My Trips" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravelDemo.Trips.Default" MasterPageFile="~/Site.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">

  <h1><%: Page.Title %></h1>

  <a href="Details?mode=add">Add a New Trip</a>

  <br />

  <asp:GridView runat="server" ID="myGrid" AutoGenerateColumns="false" SelectMethod="myGrid_GetData" AllowSorting="true">
    <Columns>
      <asp:HyperLinkField HeaderText="Destination" DataTextField="DestinationName" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Trips/Details?id={0}" />
      <asp:BoundField DataField="DepartureDateTimeUtc" HeaderText="Departure" />
      <asp:BoundField DataField="ReturnDateTimeUtc" HeaderText="Return"  />
    </Columns>
  </asp:GridView>

</asp:Content>