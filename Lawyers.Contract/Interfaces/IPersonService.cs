using Lawyers.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Interfaces
{
    public interface IPersonService
    {
        List<LawyerModel> LawyersList();

        List<AccountantModel> AccountantsList();

        List<AdministratorModel> AdministratorsRRHHList();

        List<SecretaryModel> SecretariesList();

        List<ClientModel> ClientsList();

        void Create(LawyerModel Lawyer);

        void Create(AccountantModel Accountant);

        void Create(AdministratorModel Administrator);

        void Create(SecretaryModel Secretary);

        void Create(ClientModel Client);

        LawyerModel Instance(PersonModel Person);


    }
}
