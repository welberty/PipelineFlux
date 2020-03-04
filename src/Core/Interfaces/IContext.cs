namespace PipelineFlux.Core.Interfaces
{
    public interface IContext<T>
    {
        void SetResult(T value);
        T GetResult();
    }
};