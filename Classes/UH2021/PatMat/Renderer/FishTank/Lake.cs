using System;
using System.Collections;
using System.Collections.Generic;
using GMath;
using Renderer.CGraphics;

namespace Renderer.FishTank
{
    class Lake : Model
    {
        public float Radius { get; private set; }
        public float Bottom { get; private set; }
        public float Top { get; private set; }

        public Lake(float radius, float bottom, float top)
        {
            Radius = radius;
            Bottom = bottom;
            Top = top;
        }

        public override IEnumerable<(float3, float4)> Samples(int n)
        {
            for (int i = 0; i < n; i++)
            {
                float x = Gfx.random() * 2 - 1;
                float y = Gfx.random() * 2 - 1;
                float z = Gfx.random() * 2 - 1;

                float norm = Gfx.sqrt(x * x + y * y + z * z);

                float radius = Gfx.random() * Radius;

                x = x * radius / norm;
                y = y * radius / norm;
                z = z * radius / norm;

                y = Math.Clamp(y, Bottom, Top);

                yield return (Gfx.float3(x, y, z), Gfx.float4(0, 0.3f, 0.5f, 0.9f));
            }
        }
    }
}