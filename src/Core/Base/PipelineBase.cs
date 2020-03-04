using System;
using System.Collections.Generic;
using PipelineFlux.Core.Interfaces;

namespace PipelineFlux.Core.Base
{
    public abstract class PipelineBase<T> : IPipeline<T>
    {
        private List<IMiddleware<T>> _steps;
        private IContext<T> _context;

        public PipelineBase(IContext<T> context)
        {
            _steps = new List<IMiddleware<T>>();
            _context = context;
        }
        public IPipeline<T> AddStep(IMiddleware<T> step)
        {
            _steps.Add(step);
            return this;
        }

        public void Execute()
        {
            foreach (var item in _steps)
            {
                if (item.ShouldExecute(_context))
                    item.Execute(_context);
            }
        }

        public T GetResult()
        {
            return _context.GetResult();
        }

        public IPipeline<T> SetContext(IContext<T> context)
        {
            _context = context;
            return this;
        }
    }
}