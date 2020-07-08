using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using prueba.data;
using prueba.Models;

namespace prueba.repository
{
    public class ventaRepository
    {
        private readonly pruebaContext context = null;
        public ventaRepository(pruebaContext ctx)
        {
            context = ctx;
        }

        public List<Ventas> list()
        {
            var data = context.ventas.ToList();
            return data;
        }//lista las ventas

        public int add(ventaDetalle venta) {

            using (context)
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var cabezera = venta.cabezera;
                        cabezera.fecha = DateTime.UtcNow;
                        cabezera.facturado = 0;
                        cabezera.borrado = 0;
                        context.ventas.Add(cabezera);
                        context.SaveChanges();//guarda la cabezera

                        var detalle = venta.detalle;
                        detalle.idventa = cabezera.Id;
                        context.ventasdetalles.Add(detalle);
                        context.SaveChanges(); //guarda el detalle

                        var producto = context.productos.Find(detalle.idproducto);
                        producto.existencia -= detalle.cantidad;
                        context.SaveChanges(); //descarga la cantidad del producto
                        transaction.Commit();
                        return cabezera.Id;

                    }catch(Exception e)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        } //crea la venta


        public int addDetail(Ventasdetalle detalle)
        {
            using (context)
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var cabezera = context.ventas.Find(detalle.idventa);
                        cabezera.total += detalle.subtotal; //suma el subtotal al total del producto
                        context.SaveChanges();//guarda el cambio
                        context.ventasdetalles.Add(detalle);
                        context.SaveChanges();
                        var producto = context.productos.Find(detalle.idproducto);
                        producto.existencia -= detalle.cantidad;
                        context.SaveChanges(); //descarga la cantidad del producto
                        transaction.Commit();
                        return cabezera.Id;

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }//agrega un producto ala factura ya creada

        public int delete(int id)
        {
            using (context)
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var cabezera = context.ventas.Find(id);
                        cabezera.borrado = 1;
                        context.SaveChanges();
                        var detalle = context.ventasdetalles.Where(d => d.idventa == id);
                        foreach (Ventasdetalle i in detalle)
                        {
                            var producto = context.productos.Find(i.idproducto);
                            producto.existencia += i.cantidad;
                            context.SaveChanges();
                        }
                        transaction.Commit();
                        return cabezera.Id;

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        } //borra la venta y devuelve el producto





    }
}
