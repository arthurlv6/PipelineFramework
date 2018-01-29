

using System;

namespace PipelineFramework
{
    public abstract class PipelineModule<T> where T : PipelineEvent
    {

        public abstract void Initialize(T events);

    }
}
