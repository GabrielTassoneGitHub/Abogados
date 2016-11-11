using Lawyers.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lawyers.Contract.Entities;
using Lawyers.DataAccess;
using WebMatrix.WebData;

namespace Lawyers.Services
{
    public class PersonService : IPersonService
    {
        #region Accountants
        public void Create(AccountantModel Contador)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                db.Persons.Add(new Person()
                {
                    PersonId = Contador.PersonId,
                    UserId = Contador.UserId,
                    Name = Contador.Name,
                    LastName = Contador.LastName,
                    DocTypeId = Contador.DocType.DocTypeId,
                    DocNumber = Contador.DocNumber,
                    BirthDate = Contador.BirthDate,
                    PhoneNumber = Contador.PhoneNumber,
                    Nationality = Contador.Nationality,
                    City = Contador.City,
                    Province = Contador.Province,
                    Genre = Contador.Genre,
                    ProfessionId = Contador.Profession.ProfessionId,
                    Description = Contador.Description,
                });

                db.Accountants.Add(new Accountant()
                {
                    AccountantId = Contador.AccountantId,
                    PersonId = Contador.PersonId,
                });

                db.SaveChanges();
            }
        }

        public List<AccountantModel> AccountantsList()
        {
            throw new NotImplementedException();
        }
        public AccountantModel InstanciaContador(PersonModel Person)
        {
            var nuevoContador = new AccountantModel();
            nuevoContador.PersonId = Person.PersonId;
            nuevoContador.UserId = WebSecurity.CurrentUserId;
            nuevoContador.Name = Person.Name;
            nuevoContador.LastName = Person.LastName;
            nuevoContador.DocType = Person.DocType;
            nuevoContador.DocNumber = Person.DocNumber;
            nuevoContador.BirthDate = Person.BirthDate;
            nuevoContador.Nationality = Person.Nationality;
            nuevoContador.Province = Person.Province;
            nuevoContador.City = Person.City;
            nuevoContador.Profession = Person.Profession;
            nuevoContador.Genre = Person.Genre;
            nuevoContador.Description = Person.Description;
            nuevoContador.PhoneNumber = Person.PhoneNumber;

            return nuevoContador;
        }
        #endregion

        #region AdministratorsRRHH
        public void Create(AdministratorModel Administrator)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                db.Persons.Add(new Person()
                {
                    PersonId = Administrator.PersonId,
                    UserId = Administrator.UserId,
                    Name = Administrator.Name,
                    LastName = Administrator.LastName,
                    DocTypeId = Administrator.DocType.DocTypeId,
                    DocNumber = Administrator.DocNumber,
                    BirthDate = Administrator.BirthDate,
                    PhoneNumber = Administrator.PhoneNumber,
                    Nationality = Administrator.Nationality,
                    City = Administrator.City,
                    Province = Administrator.Province,
                    Genre = Administrator.Genre,
                    ProfessionId = Administrator.Profession.ProfessionId,
                    Description = Administrator.Description,
                });

                db.Administrators.Add(new Administrator()
                {
                    AdministratorId = Administrator.AdministratorId,
                    PersonId = Administrator.PersonId,
                });

                db.SaveChanges();
            }
        }
        public List<AdministratorModel> AdministratorsRRHHList()
        {
            throw new NotImplementedException();
        }
        public AdministratorModel InstanciaAdminRRHH(PersonModel person)
        {
            var nuevoAdminRRHH = new AdministratorModel();
            nuevoAdminRRHH.PersonId = person.PersonId;
            nuevoAdminRRHH.UserId = WebSecurity.CurrentUserId;
            nuevoAdminRRHH.Name = person.Name;
            nuevoAdminRRHH.LastName = person.LastName;
            nuevoAdminRRHH.DocType = person.DocType;
            nuevoAdminRRHH.DocNumber = person.DocNumber;
            nuevoAdminRRHH.BirthDate = person.BirthDate;
            nuevoAdminRRHH.Nationality = person.Nationality;
            nuevoAdminRRHH.Province = person.Province;
            nuevoAdminRRHH.City = person.City;
            nuevoAdminRRHH.Profession = person.Profession;
            nuevoAdminRRHH.Genre = person.Genre;
            nuevoAdminRRHH.Description = person.Description;
            nuevoAdminRRHH.PhoneNumber = person.PhoneNumber;

            return nuevoAdminRRHH;
        }
        #endregion

        #region Clients
        public void Create(ClientModel Cliente)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                db.Persons.Add(new Person()
                {
                    PersonId = Cliente.PersonId,
                    UserId = Cliente.UserId,
                    Name = Cliente.Name,
                    LastName = Cliente.LastName,
                    DocTypeId = Cliente.DocType.DocTypeId,
                    DocNumber = Cliente.DocNumber,
                    BirthDate = Cliente.BirthDate,
                    PhoneNumber = Cliente.PhoneNumber,
                    Nationality = Cliente.Nationality,
                    City = Cliente.City,
                    Province = Cliente.Province,
                    Genre = Cliente.Genre,
                    Description = Cliente.Description,
                });

                db.Clients.Add(new Client()
                {
                    ClientId = Cliente.ClientId,
                    PersonId = Cliente.PersonId,
                });

                db.SaveChanges();
            }
        }

        public List<ClientModel> ClientsList()
        {
            throw new NotImplementedException();
        }
        public ClientModel InstanciaCliente(PersonModel Person)
        {
            var nuevoCliente = new ClientModel();
            nuevoCliente.PersonId = Person.PersonId;
            nuevoCliente.UserId = WebSecurity.CurrentUserId;
            nuevoCliente.Name = Person.Name;
            nuevoCliente.LastName = Person.LastName;
            nuevoCliente.DocType = Person.DocType;
            nuevoCliente.DocNumber = Person.DocNumber;
            nuevoCliente.BirthDate = Person.BirthDate;
            nuevoCliente.Nationality = Person.Nationality;
            nuevoCliente.Province = Person.Province;
            nuevoCliente.City = Person.City;
            nuevoCliente.Profession = Person.Profession;
            nuevoCliente.Genre = Person.Genre;
            nuevoCliente.Description = Person.Description;
            nuevoCliente.PhoneNumber = Person.PhoneNumber;

            return nuevoCliente;
        }

        public ClientModel EditClient()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var user = db.Persons.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
                var cliente = db.Clients.FirstOrDefault(x => x.PersonId == user.PersonId);
                ClientModel _cliente = new ClientModel()
                {
                    PersonId = cliente.PersonId,
                    UserId = user.UserId,
                    ClientId = cliente.ClientId,
                    Name = user.Name,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Nationality = user.Nationality,
                    Province = user.Province,
                    City = user.City,
                    Genre = user.Genre,
                    Description = user.Description,
                    PhoneNumber = user.PhoneNumber,
                };
                return _cliente;
            }


        }
        public bool EditClient(int id, ClientModel cliente)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                try
                {
                    var user = db.Persons.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
                    var clienteEditado = db.Persons.FirstOrDefault(x => x.PersonId == user.PersonId);                                  
                    clienteEditado.Name = cliente.Name;
                    clienteEditado.LastName = cliente.LastName;
                    clienteEditado.BirthDate = cliente.BirthDate;
                    clienteEditado.Nationality = cliente.Nationality;
                    clienteEditado.Province = cliente.Province;
                    clienteEditado.City = cliente.City;
                    clienteEditado.Genre = cliente.Genre;
                    clienteEditado.Description = cliente.Description;
                    clienteEditado.PhoneNumber = cliente.PhoneNumber;
                    db.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;
                }

            }
        }
        #endregion

        #region Secretaries
        public void Create(SecretaryModel Secretary)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                db.Persons.Add(new Person()
                {
                    PersonId = Secretary.PersonId,
                    UserId = Secretary.UserId,
                    Name = Secretary.Name,
                    LastName = Secretary.LastName,
                    DocTypeId = Secretary.DocType.DocTypeId,
                    DocNumber = Secretary.DocNumber,
                    BirthDate = Secretary.BirthDate,
                    PhoneNumber = Secretary.PhoneNumber,
                    Nationality = Secretary.Nationality,
                    City = Secretary.City,
                    Province = Secretary.Province,
                    Genre = Secretary.Genre,
                    ProfessionId = Secretary.Profession.ProfessionId,
                    Description = Secretary.Description,
                });

                db.Secretaries.Add(new Secretary()
                {
                    SecretaryId = Secretary.SecretaryId,
                    PersonId = Secretary.PersonId,
                });

                db.SaveChanges();
            }
        }

        public List<SecretaryModel> SecretariesList()
        {
            throw new NotImplementedException();
        }
        public SecretaryModel InstanciaSecretaria(PersonModel person)
        {
            var nuevaSecretaria = new SecretaryModel();
            nuevaSecretaria.PersonId = person.PersonId;
            nuevaSecretaria.UserId = WebSecurity.CurrentUserId;
            nuevaSecretaria.Name = person.Name;
            nuevaSecretaria.LastName = person.LastName;
            nuevaSecretaria.DocType = person.DocType;
            nuevaSecretaria.DocNumber = person.DocNumber;
            nuevaSecretaria.BirthDate = person.BirthDate;
            nuevaSecretaria.Nationality = person.Nationality;
            nuevaSecretaria.Province = person.Province;
            nuevaSecretaria.City = person.City;
            nuevaSecretaria.Profession = person.Profession;
            nuevaSecretaria.Genre = person.Genre;
            nuevaSecretaria.Description = person.Description;
            nuevaSecretaria.PhoneNumber = person.PhoneNumber;

            return nuevaSecretaria;
        }
        #endregion

        #region Lawyers
        public void Create(LawyerModel Abogado)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                db.Persons.Add(new Person()
                {
                    PersonId = Abogado.PersonId,
                    UserId = Abogado.UserId,
                    Name = Abogado.Name,
                    LastName = Abogado.LastName,
                    DocTypeId = Abogado.DocType.DocTypeId,
                    DocNumber = Abogado.DocNumber,
                    BirthDate = Abogado.BirthDate,
                    PhoneNumber = Abogado.PhoneNumber,
                    Nationality = Abogado.Nationality,
                    City = Abogado.City,
                    Province = Abogado.Province,
                    Genre = Abogado.Genre,
                    ProfessionId = Abogado.Profession.ProfessionId,
                    Description = Abogado.Description,
                });

                db.Lawyers.Add(new Lawyer()
                {
                    LawyerId = Abogado.LawyerId,
                    SpecializationId = Abogado.Specialization.SpecializationId,
                    PersonId = Abogado.PersonId,                                        
                });
                
                db.SaveChanges();
            }
        }

        public List<LawyerModel> LawyersList()
        {
            throw new NotImplementedException();
        }

        public LawyerModel InstanciaAbogado(PersonModel Person)
        {
            var nuevoAbogado = new LawyerModel();
            nuevoAbogado.PersonId = Person.PersonId;
            nuevoAbogado.UserId = WebSecurity.CurrentUserId;
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

        public LawyerModel BuscarAbogado()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var persona = db.Persons.Where(x => x.UserId == WebSecurity.CurrentUserId).Select(x => x.PersonId).SingleOrDefault();

                var _abogado = db.Lawyers.Where(x => x.PersonId == persona).Select(x => x).SingleOrDefault();

                var abogado = new LawyerModel()
                {
                    PersonId = _abogado.PersonId,
                    UserId = WebSecurity.CurrentUserId,
                    
            };
                return abogado;
            }
            
        }

        public bool ExisteAbogado(int id)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var persona = db.Persons.Where(x => x.UserId == WebSecurity.CurrentUserId).Select(x => x.PersonId).SingleOrDefault();
                var abogado = db.Lawyers.Where(x => x.PersonId == persona).SingleOrDefault();
                if (abogado == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        #endregion

        public LawyerModel EditLawyer()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var user = db.Persons.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
                var abogado = db.Lawyers.FirstOrDefault(x => x.PersonId == user.PersonId);
                LawyerModel _abogado = new LawyerModel()
                {
                    PersonId = abogado.PersonId,
                    UserId = user.UserId,
                    LawyerId = abogado.LawyerId,
                    Name = user.Name,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Nationality = user.Nationality,
                    Province = user.Province,
                    City = user.City,
                    Genre = user.Genre,
                    Description = user.Description,
                    PhoneNumber = user.PhoneNumber,
                };
                return _abogado;
            }


        }
        public bool EditLawyer(int id, LawyerModel abogado)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                try
                {
                    var user = db.Persons.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
                    var abogadoEditado = db.Persons.FirstOrDefault(x => x.PersonId == user.PersonId);
                    abogadoEditado.Name = abogado.Name;
                    abogadoEditado.LastName = abogado.LastName;
                    abogadoEditado.BirthDate = abogado.BirthDate;
                    abogadoEditado.Nationality = abogado.Nationality;
                    abogadoEditado.Province = abogado.Province;
                    abogadoEditado.City = abogado.City;
                    abogadoEditado.Genre = abogado.Genre;
                    abogadoEditado.Description = abogado.Description;
                    abogadoEditado.PhoneNumber = abogado.PhoneNumber;
                    abogadoEditado.ProfessionId = abogado.Profession.ProfessionId;
                    db.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;
                }

            }
        }
    }
}
