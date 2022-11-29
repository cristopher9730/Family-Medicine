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
    public class ComponenteCrudFactory : CrudFactory
    {
        private ComponenteMapper mapper;

        public ComponenteCrudFactory() : base()
        {
            mapper = new ComponenteMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var componente = (Componente)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(componente);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var componente = (Componente)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(componente);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var componente = (Componente)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(componente);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsComponente = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsComponente)
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
                var objsComponente = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsComponente, typeof(T));


            }
            return default(T);


        }

    }
}
