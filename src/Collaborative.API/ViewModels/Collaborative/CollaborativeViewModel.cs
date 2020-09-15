namespace Collaborative.API.ViewModels.Collaborative
{
    public class CollaborativeViewModel
    {
        public CollaborativeViewModel() { }

        public CollaborativeViewModel(int id, string name, string phone, string phone2, string cpf, string cnpj, string mail)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Phone2 = phone2;
            CPF = cpf;
            CNPJ = cnpj;
            Mail = mail;
        }

        public CollaborativeViewModel(string name, string phone, string phone2, string cpf, string cnpj, string mail)
        {
            Name = name;
            Phone = phone;
            Phone2 = phone2;
            CPF = cpf;
            CNPJ = cnpj;
            Mail = mail;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Mail { get; set; }
    }
}
