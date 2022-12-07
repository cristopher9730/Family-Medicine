﻿using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class ExamenCrudFactory : CrudFactory
    {
        private ExamenMapper mapper;

        public ExamenCrudFactory() : base()
        {
            mapper = new ExamenMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var examen = (Examen)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(examen);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var examen = (Examen)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(examen);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var examen = (Examen)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(examen);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsExamen = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsExamen)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public List<T> ListarTodosPorId<T>(int id)
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodosPorId(id));



            if (listResult.Count > 0)
            {
                var objsExamen = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsExamen)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public override T ListarPorID<T>(int id)
        {


            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarPorId(id));

            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                dicc = listResult[0];
                var objsExamen = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsExamen, typeof(T));


            }
            return default(T);


        }
    }
}
