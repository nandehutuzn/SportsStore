using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServices.Models;
using System.Web.Http;

namespace WebServices.Controllers
{
    public class WebController : ApiController
    {
        private ReservationRepository _repo = ReservationRepository.Current;

        public IEnumerable<Reservation> GetAllRreservations()
        {
            return _repo.GetAll();
        }

        public Reservation GetRreservation(int id)
        {
            return _repo.Get(id);
        }

        public Reservation PostReservation(Reservation item)
        {
            return _repo.Add(item);
        }

        public bool PutReservation(Reservation item)
        {
            return _repo.Update(item);
        }

        public void DeleteReservation(int id)
        {
            _repo.Remove(id);
        }
    }
}