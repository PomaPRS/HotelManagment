namespace Hotel.Web.Common
{
    public interface IModelBuilder<TViewModel, TEntity>
    {
        TViewModel CreateFrom(TEntity entity);
        TViewModel Rebuild(TViewModel model);
    }
}