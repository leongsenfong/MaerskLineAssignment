using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaerskLineAssignment.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        [ForeignKey("Ship")]
        public int ShipID { get; set; }
        public Ship Ship { get; set; }

        [ForeignKey("Container")]
        public int ContainerID { get; set; }
        public Container Container { get; set; }

        [DataType(DataType.Currency)]
        public Double Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [ForeignKey("Shipyard")]
        public int DepartureShipyardID { get; set; }
        public virtual Shipyard Shipyard { get; set; }

        [ForeignKey("Shipyard1")]
        public int ArrivalShipyardID { get; set; }
        public virtual Shipyard Shipyard1 { get; set; }
    }
}