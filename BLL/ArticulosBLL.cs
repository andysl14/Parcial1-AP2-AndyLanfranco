using Microsoft.EntityFrameworkCore;
using Parcial1_AP2_AndyLanfranco.DAL;
using Parcial1_AP2_AndyLanfranco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Parcial1_AP2_AndyLanfranco.BLL
{
    public class ArticulosBLL
    {
        private Contexto _dbContext;

        public ArticulosBLL(Contexto _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<bool> Existe(int id)
        {
            bool pass = false;

            try
            {
                pass = await _dbContext.Articulos.AnyAsync(a => a.ProductoId == id);
            }
            catch
            {
                throw;
            }

            return pass;
        }

        private async Task<bool> Insertar(Articulos articulo)
        {
            bool pass = false;

            try
            {
                await _dbContext.Articulos.AddAsync(articulo);
                pass = await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }

            return pass;
        }

        public async Task<bool> Modificar(Articulos articulo)
        {
            bool pass = false;

            try
            {
                _dbContext.Entry(articulo).State = EntityState.Modified;
                pass = await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }

            return pass;
        }

        public async Task<bool> Guardar(Articulos articulo)
        {
            if (!await Existe(articulo.ProductoId))
                return await Insertar(articulo);
            else
                return await Modificar(articulo);
        }

        public async Task<Articulos> Buscar (int id)
        {
            Articulos articulo;

            try
            {
                articulo = await _dbContext.Articulos.FindAsync(id);
            }

            catch
            {
                throw;
            }

            return articulo;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool eliminado = false;

            try
            {
                var encontrado = await _dbContext.Articulos.FindAsync(id);

                if(encontrado != null)
                {
                    _dbContext.Articulos.Remove(encontrado);
                    eliminado = await _dbContext.SaveChangesAsync() > 0;
                }
            }

            catch
            {
                throw;
            }

            return eliminado;
        }

        public async Task<List<Articulos>> GetArticulos()
        {
            List<Articulos> lista = new List<Articulos>();

            try
            {
                lista = await _dbContext.Articulos.ToListAsync();
            }

            catch
            {
                throw;
            }

            return lista;
        }

        public async Task<List<Articulos>> GetArticulos(Expression<Func<Articulos, bool>> criterio)
        {
            List<Articulos> lista = new List<Articulos>();

            try
            {
                lista = await _dbContext.Articulos.Where(criterio).ToListAsync();
            }
            catch
            {
                throw;
            }

            return lista;
        }
    }
}
