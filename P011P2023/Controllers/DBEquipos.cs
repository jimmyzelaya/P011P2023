using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace P011P2023.Controllers
{
    public class DBEquipos
    {
        // Global Variables
        readonly SQLiteAsyncConnection _conexion;

        // Constructor Vacio
        public DBEquipos()
        { }

        public DBEquipos(String dbpath)
        {
            _conexion = new SQLiteAsyncConnection(dbpath);

            // Creacion de Objetos de Base de dartos
            _conexion.CreateTableAsync<Models.Equipos>().Wait();
        }

        // CRUD - Create / Read / Update/ Delete

        public Task<int> StoreEquipo(Models.Equipos equipo)
        {
            if (equipo.Id == 0)
            {
                return _conexion.InsertAsync(equipo);
            }
            else
            {
                return _conexion.UpdateAsync(equipo);
            }
        }

        // Read

        public Task<List<Models.Equipos>> ListaEquipos()
        {
            return _conexion.Table<Models.Equipos>().ToListAsync();
        }

        public Task<Models.Equipos> GetEquipo(int pid)
        {
            return _conexion.Table<Models.Equipos>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        public Task<int> DeleteEquipo(Models.Equipos equipos)
        {
            return _conexion.DeleteAsync(equipos);
        }


    }
}