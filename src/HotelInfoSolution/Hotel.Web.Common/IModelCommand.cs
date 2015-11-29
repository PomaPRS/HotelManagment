namespace Hotel.Web.Common
{
    public interface IModelCommand<TInput>
    {
        void Execute(TInput model);
    }
}