using Lawyers.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lawyers.Contract.Entities;
using Lawyers.DataAccess;

namespace Lawyers.Services
{
    public class DocTypeService : IDocTypeService
    {
        public List<DocTypeModel> DocTypesList()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var tiposDoc = db.DocTypes.Select(x => new DocTypeModel()
                {
                    DocTypeId = x.DocTypeId,
                    DocType = x.DocType1,
                }).ToList();

                return tiposDoc;
            }
        }
    }
}
