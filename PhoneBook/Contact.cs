using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Contact //record
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BDay { get; set; }
        public string ImageUri { get; set; }
        public string Note { get; set; }
        public int Id { get; set; }
    }
}
