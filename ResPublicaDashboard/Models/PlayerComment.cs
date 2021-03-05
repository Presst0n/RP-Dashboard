using System;
using System.Collections.Generic;
using System.Text;

namespace ResPublicaDashboard.Models
{
    public class PlayerComment
    {
        public string Author { get; set; }
        public string Nick { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
