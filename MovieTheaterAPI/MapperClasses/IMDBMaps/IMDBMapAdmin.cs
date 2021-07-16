using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperClasses
{
    public class IMDBMapAdmin
    {
        public string Title { get; set; }

        public string MovieID { get; set; }

        public string Summary { get; set; }

        public string[] Actors { get; set; }

        public string Image { get; set; }

        public string runtime { get; set; }

    }
}
