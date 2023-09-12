namespace Woofhub
{
    internal class Canino
    {
        private int _idCanino;
        public string nome
        {
            get => _nroPortas;
            set => _nroPortas = value;
        }

        {
            get => _nroPortas;
            set => _nroPortas = value;
        }


    public Carro(
            string placa,
            Modelo modelo,
            string descricao,
            Cor corExterna,
            int nroPortas) :
            base(placa, modelo, descricao, corExterna)
        {
            _nroPortas = nroPortas;
        }
        public override void Mostrar()
        {
            Console.WriteLine("Placa: " + _placa);
            Console.WriteLine("Modelo: " + _modelo);
            Console.WriteLine("Descrição: " + _descricao);
            Console.WriteLine("Cor externa: " + _corExterna);
            Console.WriteLine("Número de portas: " + _nroPortas);
        }
    }
}
