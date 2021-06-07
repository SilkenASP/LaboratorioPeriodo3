using LaboratorioPWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioPWA.Repository
{
    public interface IJuego
    {
        Response GetSortedGames();
    }
}
