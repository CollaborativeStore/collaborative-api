namespace Collaborative.API.ViewModels.Collaborator
{
    public class CollaboratorInsertViewModel
    {
        public CollaboratorInsertViewModel() { }

        public CollaboratorInsertViewModel(string name, string phone, string phone2, string cPF, string cNPJ, string mail)
        {
            Name = name;
            Phone = phone;
            Phone2 = phone2;
            CPF = cPF;
            CNPJ = cNPJ;
            Email = mail;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
    }
}
