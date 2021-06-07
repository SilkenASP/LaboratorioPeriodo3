using LaboratorioPWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioPWA.Repository
{
    public class RCategoria : ICrudGeneral<categoria>
    {
        private readonly Model1 db = new Model1();
        public Response Delete(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var item = db.categoria.Find(id);
                if (item == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun registro con ese ID"
                    };
                }
                db.categoria.Remove(item);
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
                var lista = db.categoria.ToList();
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
                var elemento = db.categoria.Find(id);
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

        public Response Post(categoria item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.categoria.Add(item);
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

        public Response Update(categoria item, int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var elemento = db.categoria.Find(id);
                if (elemento == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun item para actualizar"
                    };
                }
                elemento.imagenCat = item.imagenCat;
                elemento.nomCategoria = item.nomCategoria;
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