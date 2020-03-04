namespace PipelineFlux.Core.Interfaces
{
    public interface IPipeline<T>
    {
        IPipeline<T> AddStep(IMiddleware<T> step);
        void Execute();
        IPipeline<T> SetContext(IContext<T> context);
        T GetResult();

    }
}