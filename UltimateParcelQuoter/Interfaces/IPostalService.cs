namespace UltimateParcelQuoter.Interfaces
{
    public interface IPostalService<T, TResult>
    {
        Task<TResult> Quote(T entity);
    }
}