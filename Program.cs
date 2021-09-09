using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    class Program
    {
        static FilmeRepositorio repositorioFilmes = new FilmeRepositorio();//Repositório de Filmes
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Listar();
						break;
					case "2":
						Inserir();
						break;
					case "3":
						Atualizar();
						break;
					case "4":
						Excluir();
						break;
					case "5":
						Visualizar();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Excluir()
		{
			Console.WriteLine("Você deseja excluir: ");
			Console.WriteLine("[1] FILMES" + Environment.NewLine + "[2] SERIE");
            int opcao = int.Parse(Console.ReadLine());
			int indiceSerie=0, indiceFilme=0;

			if(opcao == 1)
			{
				Console.Write("Digite o id da filme: ");
				indiceFilme = int.Parse(Console.ReadLine());
				repositorioFilmes.Exclui(indiceFilme);	
			}
			else
			{
				Console.Write("Digite o id da série: ");
				indiceSerie = int.Parse(Console.ReadLine());
				repositorio.Exclui(indiceSerie);				
			}			
		}

        private static void Visualizar()
		{
			Console.WriteLine("Você deseja visualizar: ");
			Console.WriteLine("[1] FILMES" + Environment.NewLine + "[2] SERIES");
            int opcao = int.Parse(Console.ReadLine());

			Console.Write("Digite o id do filme: ");
			int	indice = int.Parse(Console.ReadLine());

			if(opcao == 1)
			{
				VisualizarFilme(indice);				
			}
			else if (opcao == 2)
			{
				VisualizarSerie(indice);
			}
		}

        private static void VisualizarFilme(int indice)
		{
			var filme = repositorioFilmes.RetornaPorId(indice);
			Console.WriteLine(filme);
		}

        private static void VisualizarSerie(int indice)
		{
			var serie = repositorio.RetornaPorId(indice);
			Console.WriteLine(serie);
		}

        private static void Atualizar()
		{
			Console.WriteLine("Você deseja atualizar: ");
			Console.WriteLine("[1] FILMES" + Environment.NewLine + "[2] SERIES");
            int opcao = int.Parse(Console.ReadLine());

			int indiceFilme =0, indiceSerie =0;

			if(opcao == 1)
			{
				Console.Write("Digite o id do filme: ");
				indiceFilme = int.Parse(Console.ReadLine());
			}
			else if (opcao == 2)
			{
				Console.Write("Digite o id da série: ");
				indiceSerie = int.Parse(Console.ReadLine());
			}

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

			if(opcao == 1)
			{
				Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			    repositorioFilmes.Atualiza(indiceFilme, atualizaFilme);
			}
			else if (opcao == 2)
			{
				Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			    repositorio.Atualiza(indiceSerie, atualizaSerie);
			}
		}

        private static void Listar()
		{	
            Console.WriteLine("Escolha uma opção: ");
			Console.WriteLine("[1] FILMES" + Environment.NewLine + "[2] SERIES");
            int opcao = int.Parse(Console.ReadLine());
            
			if(opcao == 1)
			{
				Console.WriteLine(" -- LISTAR FILMES -- ");
				var listaFilmes = repositorioFilmes.Lista();
				if (listaFilmes.Count == 0)
				{
					Console.WriteLine("[ERRO 01] Nenhum filme cadastrado.");
					return;
				}

				foreach (var filme in listaFilmes)
				{
					var filmeExcluido = filme.retornaExcluido();
					Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (filmeExcluido ? "*Excluído*" : ""));
				}
			}
			else
			{
				Console.WriteLine(" -- LISTAR SÉRIES -- ");
				var listaSeries = repositorio.Lista();
				if (listaSeries.Count == 0)
				{
					Console.WriteLine("[ERRO] Nenhuma série cadastrada.");
					return;
				}

				foreach (var serie in listaSeries)
				{
					var serieExcluida = serie.retornaExcluido();
					Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (serieExcluida ? "*Excluído*" : ""));
				}
			}
		}

        private static void Inserir()
		{
			Console.WriteLine("-- INSERIR --");
            Console.WriteLine("Escolha uma opção: ");
			Console.WriteLine("[1] FILMES" + Environment.NewLine + "[2] SERIES");
			int opcao = int.Parse(Console.ReadLine());


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();
            
            if(opcao == 1)
            {
			    Filme novoFilme = new Filme(id: repositorioFilmes.ProximoId(),
									genero: (Genero)entradaGenero,
									titulo: entradaTitulo,
									ano: entradaAno,
									descricao: entradaDescricao);
                repositorioFilmes.Insere(novoFilme);
				Console.WriteLine("FILME INSERIDO COM SUCESSO!");
            }
            else if(opcao == 2)
            {
                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			    repositorio.Insere(novaSerie);
				Console.WriteLine("SÉRIE INSERIDA COM SUCESSO!");
            }
			
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("[1] LISTAR" + Environment.NewLine +"[2] INSERIR"+ Environment.NewLine +"[3] ATUALIZAR"+ Environment.NewLine +"[4] EXCLUIR"+ Environment.NewLine +"[5] VISUALIZAR"+ Environment.NewLine +"[C] LIMPAR TELA"+ Environment.NewLine +"[X] SAIR");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
