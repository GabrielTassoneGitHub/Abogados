using Lawyers.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Interfaces
{
    public interface IProcedureService
    {
        List<ProcedureModel> ProceduresList();

        List<ProcedureModel> ListaTramitesPorAbogado(int idAbogado);

        List<ProcedureModel> ListaTramitesPorCliente(int idCliente);

        void Create(ProcedureModel Tramite);

        string BuscarCliente(int documento);

        string BuscarEstado(int estado);

        string BuscarAbogado(int idAbogado);

        int BuscarIdAbogado();

        int BuscarIdCliente();

        int BuscarClientePorDNI(int documento);
    }
}
