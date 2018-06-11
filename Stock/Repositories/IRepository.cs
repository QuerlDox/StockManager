namespace StockSystem
{
    internal interface IRepository<T>
    {
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        void Add(T entity);
    }
}