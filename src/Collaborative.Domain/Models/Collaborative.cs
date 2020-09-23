using System;
using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class Collaborative : Person
    {
        public Collaborative() { }

        public Collaborative(int id, string name, string phone, string phone2, string cpf, string cnpj, string mail)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Phone2 = phone2;
            CPF = cpf;
            CNPJ = cnpj;
            Email = mail;
        }

        public Collaborative(string name, string phone, string phone2, string cpf, string cnpj, string mail)
        {
            Name = name;
            Phone = phone;
            Phone2 = phone2;
            CPF = cpf;
            CNPJ = cnpj;
            Email = mail;

        }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public Stock Stock { get; set; }

        public List<Collaborator> Collaborators { get; set; }
        public List<FinancialAccount> FinancialAccounts { get; set; }
        public List<Order> Orders { get; set; }
    }
}
