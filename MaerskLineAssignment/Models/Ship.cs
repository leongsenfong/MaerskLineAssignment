using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineAssignment.Models
{
    public class Ship
    {
        public int ShipID { get; set; }

        [Required]
        public String ShipName { get; set; }

        public String ShipType { get; set; }

        public int TotalContainers { get; set; }
    }
}