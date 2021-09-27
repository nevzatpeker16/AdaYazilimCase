using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Buisness.Abstract;
using Buisness.Results.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Buisness.Concrete
{
    public class TrainReservationManager:IReservationService
    {
        public IDataResult<Reservation> ReserveTrain(Tren tren, int seatsToReserve, bool canBeDifferentVagons)
        {

            if (!canBeDifferentVagons)
            {
                foreach (var vagon in tren.Vagonlar)
                {

                    if (vagon.Kapasite - vagon.DoluKoltukAdet + seatsToReserve > 0)
                    {

                        vagon.DoluKoltukAdet = vagon.DoluKoltukAdet + seatsToReserve;
                        Reservation reservation = new Reservation();
                        reservation.RezervasyonYapilabilir = true;
                        reservation.YerlesimAyrinti[0].VagonAdi = tren.Ad;
                        reservation.YerlesimAyrinti[0].KisiSayisi = seatsToReserve;
                        return new SuccessDataResult<Reservation>(reservation);
                        

                    }
                    else
                    {
                        Reservation reservation = new Reservation();
                        reservation.RezervasyonYapilabilir = false;
                        return new SuccessDataResult<Reservation>(reservation);

                    }
                    
                }
            }

            else
            {
                Reservation reservation = new Reservation();
                int trenSayac = 0;
                for (int i = seatsToReserve; i >= 0;)

                {
                    foreach (var vagon in tren.Vagonlar)
                    {
                        int yer = vagon.Kapasite - vagon.DoluKoltukAdet;
                    if (  yer  > 0)
                    {

                        if (yer > i)
                        {

                            reservation.YerlesimAyrinti[trenSayac].VagonAdi = vagon.Ad;
                            reservation.YerlesimAyrinti[trenSayac].KisiSayisi = i;
                            return new SuccessDataResult<Reservation>(reservation);
                        }
                        else
                        {
                            reservation.YerlesimAyrinti[trenSayac].VagonAdi = vagon.Ad;
                            reservation.YerlesimAyrinti[trenSayac].KisiSayisi = i;
                        }

                        i--;
                    }

                    if (i == 0)
                    {
                        reservation.RezervasyonYapilabilir = true; 
                        return new SuccessDataResult<Reservation>(reservation);
                    }




                    
                    }

                    trenSayac++;
                }

                reservation.RezervasyonYapilabilir = false;
                reservation.YerlesimAyrinti = null;
                return new SuccessDataResult<Reservation>(reservation);
            }
            return null;
        }
        
    }
}
