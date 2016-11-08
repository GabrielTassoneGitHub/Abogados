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

        void Create(ProcedureModel Tramite);
    }
}
