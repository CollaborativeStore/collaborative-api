using Collaborative.API.ViewModels.Collaborative;

namespace Collaborative.API.ViewModels.Collaborator
{
    public class CollaboratorViewModel
    {
        public CollaboratorViewModel() { }

        public CollaboratorViewModel(int id, string name, string phone, string phone2, string cPF, string cNPJ, string mail)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Phone2 = phone2;
            CPF = cPF;
            CNPJ = cNPJ;
            Mail = mail;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Mail { get; set; }
        public CollaborativeViewModel Collaborative { get; set; }
    }
}
