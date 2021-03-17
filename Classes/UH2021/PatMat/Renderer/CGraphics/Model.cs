using System;
using System.Collections.Generic;
using GMath;

namespace Renderer.CGraphics
{
    public abstract class Model
    {
        public abstract IEnumerable<(float3, float4)> Samples(int n);
    }
}