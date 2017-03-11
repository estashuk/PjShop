using System;
using System.Collections.Generic;
using System.Linq;
using PartyJuice.DataAccess;
using PartyJuice.DbEntity;

namespace PartyJuice.Logic
{
    public class ClientBusinessLogic : BaseBusinessLogic<Client>
    {
        private readonly ClientRepository _repository = new ClientRepository();

        public void AddPhoneNumber(Guid clientId, PhoneNumber phoneNumber)
        {
            var client = _repository.GetById(clientId);
            if(client.ClientsPhoneNumbers.Contains(phoneNumber)) return;
            client.ClientsPhoneNumbers.Add(phoneNumber);
            _repository.Update(client);
        }

        public void AddPhoneNumbers(Guid clientId, IEnumerable<PhoneNumber> phoneNumbers)
        {
            var client = _repository.GetById(clientId);
            foreach (var phoneNumber in phoneNumbers)
            {
                if (!client.ClientsPhoneNumbers.Contains(phoneNumber))
                {
                    client.ClientsPhoneNumbers.Add(phoneNumber);
                }
            }
            _repository.Update(client);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Client> GetAllDeletedClients()
        {
            return _repository.GetAllDeleted();
        }

        public IEnumerable<Client> GetAllNotDeletedClients()
        {
            return _repository.GetAllNotDeleted();
        }

        public Client GetClientById(Guid clientId)
        {
            return _repository.GetById(clientId);
        } 
    }
}