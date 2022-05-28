namespace Dio.Series
{
  public class SerieRespository : IRepository<Serie>
  {
    private List<Serie> series = new List<Serie>();

    public List<Serie> List()
    {
      return series;
    }

    public Serie ReturnById(int id)
    {
      foreach (Serie serie in series)
      {
        if (serie.Id == id)
        {
          return serie;
        }
      }
      return null;
    }

    public void Add(Serie entity)
    {
      series.Add(entity);
    }

    public void Update(int id, Serie entity)
    {
      series[id] = entity;
    }

    public void Delete(int id)
    {
      series[id].excluir();
    }

    public int NextId()
    {
      return series.Count();
    }

  }

}