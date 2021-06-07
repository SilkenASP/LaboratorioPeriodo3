using LaboratorioPWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioPWA.Repository
{
    public interface ICrudGeneral<T>
    {
        Response GetAll();
        Response GetById(int id);
        Response Post(T item);
        Response Update(T item, int id);
        Response Delete(int id);
    }
}
