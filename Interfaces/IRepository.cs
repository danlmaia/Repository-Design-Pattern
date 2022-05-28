namespace Dio.Series
{
  public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        int NextId();
    }
}