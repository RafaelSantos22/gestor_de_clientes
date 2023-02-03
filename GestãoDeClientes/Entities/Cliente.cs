

namespace GestãoDeClientes.Entities
{
    [Serializable]
    internal class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public Cliente() { }

        public Cliente(string nome, string email, string cpf)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}
