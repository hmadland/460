using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace HW7.Models
{
    public class GiphyLog
    {
        [Key]
        public int giphyID { get; set; }

        public DateTime queryTime { get; set; }

        [StringLength(128)]
        public string queryClientAgent { get; set; }

        [StringLength(128)]
        public string giphyQuery { get; set; }
    }
}