﻿using eFrizer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IReservationService : ICRUDService<Model.Reservation, ReservationSearchRequest, ReservationInsertRequest , ReservationUpdateRequest>
    {
       
    }
}
