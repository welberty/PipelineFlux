namespace PipelineFlux.Core.Interfaces
{
    public interface IMiddleware<T>
    {
        void Execute(IContext<T> context);
        bool ShouldExecute(IContext<T> context);

    }
}