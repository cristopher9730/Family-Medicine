using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccess;
using DataAccess.Crud;


namespace AppLogic
{
    internal class AdminLaboratorio
    {

        public AdminLaboratorio()
        {

        }

        public string CrearLaboratorio(Laboratorio laboratorio)
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();
            laboratorioCrud.Crear(laboratorio);
            return "Laboratorio creado correctamente en base de datos";
        }

        public string EditarLaboratorio(Laboratorio laboratorio)
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();
            laboratorioCrud.Actualizar(laboratorio);
            return "Laboratorio actualizado correctamente en base de datos";
        }

        public string EliminarLaboratorio()
        {
            return "TBD";
        }

        public List<Laboratorio> DevolverTodosLaboratorios()
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();
            return laboratorioCrud.ListarTodos<Laboratorio>();
        }


    }
}
