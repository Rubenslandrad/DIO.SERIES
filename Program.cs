using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    InserirSerie();
                    break;
                    case "3":
                    AtualizarSerie();
                    break;
                    case "4":
                    ExcluirSerie();
                    break;
                    case "5":
                    VisualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();
            }

                Console.WriteLine(" Obrigado por utilizar nossos serviços");
                Console.ReadLine();
        }


        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

         
         private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
             int indiceSerie = int.Parse(Console.ReadLine());

           var serie = repositorio.RetornaPorId(indiceSerie);

           repositorio.Exclui(indiceSerie);
                                           
        }

         private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id série");
             int indiceSerie = int.Parse(Console.ReadLine());

           var serie = repositorio.RetornaPorId(indiceSerie);

           Console.WriteLine(serie);
                                           
        }

         private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie");
            int indiceSerie = int.Parse(Console.ReadLine());


           
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

             Console.Write("Digite o titulo da série:");
            string entradaTitulo = Console.ReadLine();

             Console.Write("Digite o Ano de ínicio da série:");
            int entradaAno = int.Parse(Console.ReadLine());

             Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);                                
        }



        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");


           
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

             Console.Write("Digite o titulo da série:");
            string entradaTitulo = Console.ReadLine();

             Console.Write("Digite o Ano de ínicio da série:");
            int entradaAno = int.Parse(Console.ReadLine());

             Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Insere(novaSerie);                                
        }

        private static string ObterOpcaoUsuario()
        {
             Console.WriteLine();
             Console.WriteLine(" Dio Serie a seu dispor!!!");
             Console.WriteLine(" Informe a opção desejada:");

             Console.WriteLine("1- Listar séries");
             Console.WriteLine("2- Inserir nova série");
             Console.WriteLine("3- Atualizar série");
             Console.WriteLine("4- Excluir série");
             Console.WriteLine("5- Visualizar séire");
             Console.WriteLine("C- Limpar tela");
             Console.WriteLine("X- Sair");
             Console.WriteLine();

             string OpcaoUsuario = Console.ReadLine().ToUpper();
             Console.WriteLine();
             return OpcaoUsuario;
        }
    }
}
