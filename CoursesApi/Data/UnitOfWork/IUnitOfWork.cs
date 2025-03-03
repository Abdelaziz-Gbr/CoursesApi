namespace CoursesApi.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
