using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface IObjectMapper
    {
        EntidadBase ConstruirObjeto(Dictionary<string, object> row);

        List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows);
    }
}
