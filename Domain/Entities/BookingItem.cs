using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class BookingItem
    {
        public int Id { get; set; }
        public int PartySize { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public BookingStatus Status { get; set; }
        public string Details { get; set; }
    }
}
