using ModuloUsuarios.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloUsuarios.Models.Business
{
    public class AutoServices
    {

        public Auto ObtenerAuto()
        {
            return new Auto()
            {
                Marca = "Chevrolet",
                Color = "Rojo",
                Precio = 2500
            };

        }

        public List<Auto> ObtenerAutos()
        {
            var ListaAutos = new List<Auto>();

            var auto1 = new Auto()
            {
                Marca = "Mazda",
                Color = "Verde",
                Precio = 2300
            };

            var auto2 = new Auto()
            {
                Marca = "Renault",
                Color = " Negro",
                Precio = 3000
            };

            ListaAutos.Add(auto1);
            ListaAutos.Add(auto2);

            return ListaAutos;

        }
    }



}

