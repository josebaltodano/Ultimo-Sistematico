using Domain.Enties;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestuctrura
{
    public class CalendarioRepository : ICalendarioRepository
    {
        private List<Calendario> calendarios;

        public CalendarioRepository()
        {
            calendarios = new List<Calendario>();
        }

        public void Add(Calendario c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            calendarios.Add(c);
        }

        public bool Delete(Calendario c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            return calendarios.Remove(c);
        }

        public List<Calendario> FindAll()
        {
            return calendarios;
        }

        public List<Calendario> FindAll(Predicate<Calendario> predicate)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            return calendarios.FindAll(predicate);
        }

        public int GetLastIdCuota()
        {
            return (calendarios.Count == 0) ? 0 : calendarios[calendarios.Count - 1].Id;
        }

        public void Update(Calendario c)
        {
            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            int index = calendarios.FindIndex(x => x.Id == c.Id);
            if (index < 0)
            {
                throw new ArgumentException("El elemento no existe");
            }
            calendarios.Insert(index, c);
        }
    }
}
