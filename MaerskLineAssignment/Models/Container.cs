using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineAssignment.Models
{
    public class Container
    {
        public int ContainerID { get; set; }

        public int ContainerName { get; set; }

        [Required]
        public String ContainerDescription { get; set; }

        public int ContainerWeight { get; set; }
    }
}