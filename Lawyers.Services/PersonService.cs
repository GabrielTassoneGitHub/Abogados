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
    public class PersonService : IPersonService
    {
        #region Accountants
        public void Create(AccountantModel Accountant)
        {
            throw new NotImplementedException();
        }

        public List<AccountantModel> AccountantsList()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region AdministratorsRRHH
        public void Create(AdministratorModel Administrator)
        {
            throw new NotImplementedException();
        }
        public List<AdministratorModel> AdministratorsRRHHList()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Clients
        public void Create(ClientModel Client)
        {
            throw new NotImplementedException();
        }

        public List<ClientModel> ClientsList()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Secretaries
        public void Create(SecretaryModel Secretary)
        {
            throw new NotImplementedException();
        }

        public List<SecretaryModel> SecretariesList()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Lawyers
        public void Create(LawyerModel Lawyer)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                db.Persons.Add(new Person()
                {
                    PersonId = Lawyer.PersonId,
                    UserId = Lawyer.UserId,
                    Name = Lawyer.Name,
                    LastName = Lawyer.LastName,
                    DocTypeId = Lawyer.DocType.DocTypeId,
                    DocNumber = Lawyer.DocNumber,
                    BirthDate = Lawyer.BirthDate,
                    PhoneNumber = Lawyer.PhoneNumber,
                    Nationality = Lawyer.Nationality,
                    City = Lawyer.City,
                    Province = Lawyer.Province,
                    Genre = Lawyer.Genre,
                    ProfessionId = Lawyer.Profession.ProfessionId,
                    Description = Lawyer.Description,
                });

                db.Lawyers.Add(new Lawyer()
                {
                    LawyerId = Lawyer.LawyerId,
                    SpecializationId = Lawyer.Specialization.SpecializationId,
                    PersonId = Lawyer.PersonId,                                        
                });
                
                db.SaveChanges();
            }
        }

        public List<LawyerModel> LawyersList()
        {
            throw new NotImplementedException();
        }

        public LawyerModel Instance(PersonModel Person)
        {
            var nuevoAbogado = new LawyerModel();
            nuevoAbogado.PersonId = Person.PersonId;
            nuevoAbogado.Name = Person.Name;
            nuevoAbogado.LastName = Person.LastName;
            nuevoAbogado.DocType = Person.DocType;
            nuevoAbogado.DocNumber = Person.DocNumber;
            nuevoAbogado.BirthDate = Person.BirthDate;
            nuevoAbogado.Nationality = Person.Nationality;
            nuevoAbogado.Province = Person.Province;
            nuevoAbogado.City = Person.City;
            nuevoAbogado.Profession = Person.Profession;
            nuevoAbogado.Genre = Person.Genre;
            nuevoAbogado.Description = Person.Description;
            nuevoAbogado.PhoneNumber = Person.PhoneNumber;

            return nuevoAbogado;
        }
        #endregion


    }
}
