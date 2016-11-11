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


        LawyerModel InstanciaAbogado(PersonModel Person);        

        AccountantModel InstanciaContador(PersonModel Person);

        AdministratorModel InstanciaAdminRRHH(PersonModel person);

        SecretaryModel InstanciaSecretaria(PersonModel person);

        ClientModel InstanciaCliente(PersonModel person);


        LawyerModel BuscarAbogado();

        ClientModel EditClient();

        bool EditClient(int id, ClientModel cliente);

        LawyerModel EditLawyer();

        bool EditLawyer(int id, LawyerModel abogado);

        bool ExisteAbogado(int id);       

    }
}
