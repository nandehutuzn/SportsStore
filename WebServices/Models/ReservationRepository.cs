using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class ReservationRepository
    {
        private static ReservationRepository _repo = new ReservationRepository();
        public static ReservationRepository Current {
            get { return _repo; }
        }

        private List<Reservation> _data = new List<Reservation>
        {
            new Reservation{ ReservationId = 1, ClientName = "Admin", Location = "BoardRoom"},
            new Reservation{ ReservationId = 2, ClientName = "Jacqui", Location = "Lecture Hall"},
            new Reservation{ ReservationId = 3, ClientName = "Russell", Location = "Meeting Room 1"},
        };

        public IEnumerable<Reservation> GetAll()
        {
            return _data;
        }

        public Reservation Get(int id)
        {
            return _data.FirstOrDefault(m => m.ReservationId == id);
        }

        public Reservation Add(Reservation item)
        {
            item.ReservationId = _data.Count + 1;
            _data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Reservation item = Get(id);
            if (item != null)
                _data.Remove(item);
        }

        public bool Update(Reservation item)
        {
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;

                return true;
            }
            return false;
        }
    }
}