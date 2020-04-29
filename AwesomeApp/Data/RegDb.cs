using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.ComponentModel.DataAnnotations;

namespace AwesomeApp.Data
{
    public class RegDb 
    {

        [Key]
        public int RegId { get; set; }
        public string Registration { get; set; }
        public DateTime StartTime { get; set; }

       

    }
}
