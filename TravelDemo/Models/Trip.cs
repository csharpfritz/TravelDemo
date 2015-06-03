using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDemo.Models
{

  public class Trip
  {

    [Key]
    public Guid Id { get; set; }

    public string OwnerName { get; set; }

    public string DestinationName { get; set; }

    public decimal DestinationLatitude { get; set; }

    public decimal DestinationLongitude { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
    [DataType(DataType.Date)]
    public DateTime DepartureDateTimeUtc { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime ReturnDateTimeUtc { get; set; }

  }

}