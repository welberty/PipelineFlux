using Moq;
using PipelineFlux.Core.Base;
using PipelineFlux.Core.Interfaces;
using Xunit;

namespace Pipeline.Test
{
    public class PipelineTest
    {

        private IMiddleware<int> BuildAddMiddleware(Context ctx)
        {
            var middlewareMoq = new Mock<IMiddleware<int>>();
            middlewareMoq.Setup(m => m.ShouldExecute(ctx)).Returns(true);
            middlewareMoq
                .Setup(m => m.Execute(ctx))
                .Callback<IContext<int>>(c => { c.SetResult(c.GetResult() + 1); });
            var middlewareAddOne = middlewareMoq.Object;
            return middlewareAddOne;
        }

        private IMiddleware<int> BuildSubMiddleware(Context ctx)
        {
            var middlewareMoq = new Mock<IMiddleware<int>>();
            middlewareMoq.Setup(m => m.ShouldExecute(ctx)).Returns(true);
            middlewareMoq
                .Setup(m => m.Execute(ctx))
                .Callback<IContext<int>>(c => { c.SetResult(c.GetResult() - 1); });
            var middlewareAddOne = middlewareMoq.Object;
            return middlewareAddOne;
        }

        [Fact]
        public void Should_Add_One()
        {
            //Given
            var ctx = new Context();
            var pipe = new Pipeline(ctx);
            IMiddleware<int> middlewareAddOne = BuildAddMiddleware(ctx);
            //When
            pipe.AddStep(middlewareAddOne).Execute();
            //Then
            Assert.Equal(1, pipe.GetResult());
            Assert.NotEqual(0, pipe.GetResult());
        }

        [Fact]
        public void Should_Add_Two()
        {
            //Given
            var ctx = new Context();
            var pipe = new Pipeline(ctx);
            IMiddleware<int> middlewareAddOne = BuildAddMiddleware(ctx);
            //When
            pipe
                .AddStep(middlewareAddOne)
                .AddStep(middlewareAddOne)
                .Execute();
            //Then
            Assert.Equal(2, ctx.GetResult());
            Assert.NotEqual(0, ctx.GetResult());
        }
        [Fact]
        public void Should_Sub_Two()
        {
            //Given
            var ctx = new Context();
            var pipe = new Pipeline(ctx);
            IMiddleware<int> middlewareSubOne = BuildSubMiddleware(ctx);
            //When
            pipe
                .AddStep(middlewareSubOne)
                .AddStep(middlewareSubOne)
                .Execute();
            //Then
            Assert.Equal(-2, ctx.GetResult());
            Assert.NotEqual(0, ctx.GetResult());
        }

    }

    public class Pipeline : PipelineBase<int>
    {
        public Pipeline(IContext<int> val) : base(val)
        {

        }
    }

    public class Context : IContext<int>
    {
        private int _value;
        public Context()
        {
            _value = 0;
        }
        public int GetResult()
        {
            return _value;
        }

        public void SetResult(int value)
        {
            _value = value;
        }
    }
}