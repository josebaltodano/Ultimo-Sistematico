using Domain.Enties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
  public   interface ICalendarioRepository
    {
        void Add(Calendario c);
        List<Calendario> FindAll();
        int GetLastIdCuota();
        List<Calendario> FindAll(Predicate<Calendario> predicate);
        void Update(Calendario c);
        bool Delete(Calendario c);
    }
}
