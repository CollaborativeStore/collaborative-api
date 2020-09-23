namespace Collaborative.API.ViewModels.Collaborative
{
    public class CollaborativeUpdateViewModel
    {
        public CollaborativeUpdateViewModel(string name, string phone, string phone2, string cPF, string cNPJ, string email)
        {
            Name = name;
            Phone = phone;
            Phone2 = phone2;
            CPF = cPF;
            CNPJ = cNPJ;
            Email = email;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
    }
}
