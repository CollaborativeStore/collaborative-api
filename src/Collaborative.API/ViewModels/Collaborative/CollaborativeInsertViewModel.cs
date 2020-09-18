namespace Collaborative.API.ViewModels.Collaborative
{
    public class CollaborativeInsertViewModel
    {
        public CollaborativeInsertViewModel() { }

        public CollaborativeInsertViewModel(string name, string phone, string phone2, string cpf, string cnpj, string mail)
        {
            Name = name;
            Phone = phone;
            Phone2 = phone2;
            CPF = cpf;
            CNPJ = cnpj;
            Mail = mail;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Mail { get; set; }
    }
}

