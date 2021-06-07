using LaboratorioPWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioPWA.Repository
{
    public class RJuego : ICrudGeneral<juego>,IJuego
    {
        private readonly Model1 db = new Model1();
        public Response Delete(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var item = db.juego.Find(id);
                if (item == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun registro con ese ID"
                    };
                }
                db.juego.Remove(item);
                db.SaveChanges();
                return new Response
                {
                    IsSuccess = true,
                    Message = "El registro ha sido eliminado",
                    Result = item
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }

        public Response GetAll()
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var lista = db.juego.ToList();
                return new Response
                {
                    IsSuccess = true,
                    Result = lista
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }

        public Response GetById(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var elemento = db.juego.Find(id);
                if (elemento == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun registro con ese ID"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = elemento
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }

        public Response GetSortedGames()
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var lista = db.juego.ToList();
                if (lista.Count<=0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No hay elementos para ordenar"
                    };
                }
                var SortedList = from c in lista
                                 orderby c.precio descending
                                 select c;
                return new Response
                {
                    IsSuccess = true,
                    Result = SortedList
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
            throw new NotImplementedException();
        }

        public Response Post(juego item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.juego.Add(item);
                db.SaveChanges();
                return new Response
                {
                    IsSuccess = true,
                    Result = item
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }

        public Response Update(juego item, int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var elemento = db.juego.Find(id);
                if (elemento == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun item para actualizar"
                    };
                }
                elemento.existencias = item.existencias;
                elemento.nomJuego = item.nomJuego;
                elemento.idcategoria = item.idcategoria;
                elemento.precio = item.precio;
                elemento.imagen = item.imagen;
                db.Entry(elemento).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return new Response
                {
                    IsSuccess = true,
                    Result = elemento
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }
    }
}