namespace Dio.Series
{
  class Program
  {

    static SerieRespository serieRepository = new SerieRespository();
    static void Main(string[] args)
    {
      string optionUser = GetOptions();

      while (optionUser.ToUpper() != "X")
      {
        switch(optionUser)
        {
          case "1":
            ListSeries();
            break;
          case "2":
            AddSerie();
            break;
          case "3":
            UpdateSerie();
            break;
          case "4":
            DeleteSerie();
            break;
          case "5":
            ViewSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            Console.WriteLine("Opção inválida!");
            break;
        }
        optionUser = GetOptions();
      }
      System.Console.WriteLine("Fim do programa!");
      System.Console.WriteLine( "Pressione qualquer tecla para sair...");
      System.Console.ReadKey();

    }

    private static void ViewSerie()
    {
      Console.WriteLine("Digite o ID da série que deseja visualizar: ");
      int id = Convert.ToInt32(Console.ReadLine());
      Serie serie = serieRepository.ReturnById(id);
      if (serie != null)
      {
        Console.WriteLine(serie.ToString());
      }
      else
      {
        Console.WriteLine("Série não encontrada!");
      }
    }

    private static void DeleteSerie()
    {
      Console.WriteLine("Digite o ID da série que deseja excluir:");
      int id = int.Parse(Console.ReadLine());
      System.Console.WriteLine("Deseja excluir a série com ID: " + id + "? (S/N)");
      string confirm = Console.ReadLine();
      if (confirm.ToUpper() == "S")
      {
        serieRepository.Delete(id);
        Console.WriteLine("Série excluida com sucesso!");
      }
      else
      {
        Console.WriteLine("Operação cancelada!");
      }
      serieRepository.Delete(id);
    }

    private static void UpdateSerie()
    {
      System.Console.WriteLine("Digite o Id da série que deseja atualizar:");
      int id = int.Parse(Console.ReadLine());
      foreach (Serie serie in serieRepository.List())
      {
        if (serie.Id == id)
        {
          System.Console.WriteLine("Digite o novo título da série:");
          string title = Console.ReadLine();
          System.Console.WriteLine("Digite a nova descrição da série:");
          string description = Console.ReadLine();
          System.Console.WriteLine("Digite o novo ano da série:");
          int year = int.Parse(Console.ReadLine());
          serie.Title = title;
          serie.Description = description;
          serie.Year = year;
          serieRepository.Update(id, serie);
          System.Console.WriteLine("Série atualizada com sucesso!");
          return;
        }
      }

    }

    private static void AddSerie()
    {
      System.Console.WriteLine("Add a new serie");
      foreach (int i in Enum.GetValues(typeof(Genre)))
      {
        System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
      }
      System.Console.WriteLine("Enter the genre of the serie");
      int genre = int.Parse(Console.ReadLine());
      System.Console.WriteLine("Enter the title of the serie");
      string title = Console.ReadLine();
      System.Console.WriteLine("Enter the description of the serie");
      string description = Console.ReadLine();
      System.Console.WriteLine("Enter the year of the serie");
      int year = int.Parse(Console.ReadLine());

      Serie serie = new Serie(serieRepository.NextId(), (Genre)genre, title, description, year);
      serieRepository.Add(serie);
    }

    private static void ListSeries()
    {
      System.Console.WriteLine("Series List");
      System.Console.WriteLine("=============");
      var list = serieRepository.List();
      if(list.Count() > 0)
      {
        foreach(var serie in list)
        {
          var excluido = serie.returnExcluded();
          System.Console.WriteLine("#ID {0} - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? " *Excluido*" : ""));      
        }
      }
      else
      {
        System.Console.WriteLine("Nenhuma serie cadastrada!");
        return;
      }
    }

    private static string GetOptions()
    {

      System.Console.WriteLine();
      System.Console.WriteLine("-- Menu de Opções --");
      System.Console.WriteLine("1 - Listar");
      System.Console.WriteLine("2 - Adicionar");
      System.Console.WriteLine("3 - Atualizar");
      System.Console.WriteLine("4 - Excluir");
      System.Console.WriteLine("5 - Visualizar Serie");
      System.Console.WriteLine("C - Limpar Tela"); 
      System.Console.WriteLine("X - Sair");
      System.Console.WriteLine("Escolha uma opção:");

      string optionUser = Console.ReadLine().ToUpper();
      System.Console.WriteLine();
      return optionUser;
    }
  }
}