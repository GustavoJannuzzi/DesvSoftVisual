namespace Woofhub
{
    internal class Cliente
    {
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string nomeCompleto
        {
            get => _nomeCompleto;
            set => _nomeCompleto = value;
        }
        public string cpf
        {
            get => _cpf;
            set => _cpf = value;
        }
        public Endereco()
        {
            _rua = string.Empty;
            _numero = int.Empty();
            _bairro = string.Empty;
            _cep = string.Empty;
        }
        public Endereco(string rua, int numero, string bairro, string cep)
        {
            _rua = rua;
            _numero = numero;
            _bairro = bairro;
            _cep = cep;
        }
    }
}
