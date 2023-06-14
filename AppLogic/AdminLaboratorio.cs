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
    public class AdminLaboratorio
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

        public string EliminarLaboratorio(Laboratorio laboratorio)
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();
            laboratorioCrud.Eliminar(laboratorio);
            return "Laboratorio elimindado correctamente en base de datos";
        }

        public List<Laboratorio> DevolverTodosLaboratorios()
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();
            return laboratorioCrud.ListarTodos<Laboratorio>();
        }

        public Laboratorio DevolverUnLaboratorio(Laboratorio laboratorio)
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();

            return laboratorioCrud.ListarPorID<Laboratorio>(laboratorio.LaboratorioId);
        }


    }
}
