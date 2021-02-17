using System;

namespace DIO.Series.classes
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        private static int descricao;

        static void Main(string[] args)
        {
            string OpcaoUsuario = Opcao();
            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                OpcaoUsuario = Opcao();
            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Serie");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }
            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornoId(), serie.retornoTitulo());
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova serie");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha um entre as opções");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o inicio da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao);
            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
        }

        private static string Opcao()
        {
            Console.WriteLine("");
            Console.WriteLine("Catalogando series");
            Console.WriteLine("Informe uma serie");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir Serie");
            Console.WriteLine("3 - Atualizar Serie");
            Console.WriteLine("4 - Excluir Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string Opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return Opcao;
        }
    }
}
