using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buisness.Abstract;
using Entities.Concrete;

namespace AdaYazilimCase.Controllers
{
    public class TrainReservationController : Controller
    {
         IReservationService _reservationService;
        public TrainReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }




        [HttpPost("reserveTrain")]
       public IActionResult ReserveTrain(Tren tren,int rezervasyonYapilacakKisiSayisi, bool kisilerFarkliVagonlaraYerlestirilebilir)
       {

           var result = _reservationService.ReserveTrain(tren, rezervasyonYapilacakKisiSayisi,
               kisilerFarkliVagonlaraYerlestirilebilir);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
