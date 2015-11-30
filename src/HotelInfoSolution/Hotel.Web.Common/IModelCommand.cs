namespace Hotel.Web.Common
{
    public interface IModelCommand<TInput, TEntity>
    {
        TEntity Execute(TInput model);
    }
}