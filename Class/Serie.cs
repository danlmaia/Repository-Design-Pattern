namespace Dio.Series
{
  public class Serie : EntityBase
  {
		//Atributos
    public Genre Genre { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }

    public bool excluded { get; set; }


		//Metodos
		public Serie(int id, Genre genre, string title, string description, int year)
    {
			this.Id = id;
			this.Genre = genre;
      this.Title = title;
      this.Description = description;
      this.Year = year;
      this.excluded = false;
    }

    public override string ToString()
    {
			string retorno = "";
			retorno += "Id: " + this.Id + "\n";
      retorno += "Genre: " + this.Genre + "\n";
      retorno += "Title: " + this.Title + "\n";
      retorno += "Description: " + this.Description + "\n";
      retorno += "Year: " + this.Year + "\n";
      retorno += "Excluded: " + this.excluded + "\n";

      return retorno;
    }

		public string retornaTitulo()
		{
			return this.Title;
		}

		public int retornaId()
		{
			return this.Id;
		}

    public void excluir()
    {
      this.excluded = true;
    }

    public bool returnExcluded()
    {
      return this.excluded;
    }

	}
}
