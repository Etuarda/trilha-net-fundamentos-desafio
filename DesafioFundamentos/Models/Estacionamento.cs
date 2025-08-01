// /DesafioFundamentos/Models/Estacionamento.cs

namespace DesafioFundamentos.Models
{
    // A classe Estacionamento é responsável por gerenciar todas as operações do estacionamento.
    // Ela encapsula o estado (preços e lista de veículos) e o comportamento (adicionar, remover, listar).
    public class Estacionamento
    {
        // Variáveis privadas (encapsulamento) para armazenar os preços.
        // O `private` garante que esses valores só possam ser alterados dentro desta classe,
        // mantendo a integridade dos dados.
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        // Uma lista de strings para armazenar as placas dos veículos estacionados.
        // `List<string>` é ideal para uma coleção dinâmica onde a ordem não importa.
        private List<string> veiculos = new List<string>();

        // Construtor da classe Estacionamento.
        // Ele é chamado quando uma nova instância da classe é criada,
        // e é usado para inicializar os preços com base nos valores fornecidos.
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Método para adicionar um veículo ao estacionamento.
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            // Lê a placa digitada pelo usuário e a armazena em uma variável.
            string placa = Console.ReadLine();

            // Adiciona a placa à lista de veículos estacionados.
            veiculos.Add(placa);

            Console.WriteLine($"Veículo com a placa {placa} adicionado com sucesso!");
        }

        // Método para remover um veículo do estacionamento e calcular o valor a ser pago.
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Lê a placa do veículo que será removido.
            string placa = Console.ReadLine();

            // Verifica se a placa digitada existe na lista de veículos.
            // O `.Any()` retorna `true` se a lista contiver algum elemento
            // que satisfaça a condição `x.ToUpper() == placa.ToUpper()`.
            // O `.ToUpper()` é usado para garantir que a comparação não seja sensível a maiúsculas/minúsculas.
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Lê o número de horas e converte para um tipo inteiro.
                int horas = Convert.ToInt32(Console.ReadLine());

                // Calcula o valor total do estacionamento usando a fórmula:
                // Preço inicial + (Preço por hora * Horas estacionadas).
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // Remove o veículo da lista de veículos estacionados.
                veiculos.Remove(placa);

                // Exibe uma mensagem de confirmação, informando qual veículo foi removido
                // e o valor total a ser pago. O `:F2` formata o valor para duas casas decimais.
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                // Se o veículo não for encontrado na lista, exibe uma mensagem de erro.
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        // Método para listar todos os veículos que estão atualmente estacionados.
        public void ListarVeiculos()
        {
            // Verifica se a lista de veículos não está vazia.
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                // Itera sobre cada veículo na lista e exibe a placa.
                // O `foreach` é a forma mais legível de percorrer uma coleção.
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                // Se a lista estiver vazia, exibe uma mensagem informando que não há veículos.
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}