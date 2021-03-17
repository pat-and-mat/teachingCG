using System;
using System.Collections;
using System.Collections.Generic;
using GMath;
using Renderer.CGraphics;

namespace Renderer.FishTank
{
    class FishTankGlass : Model
    {
        public float Radius { get; private set; }
        public float Bottom { get; private set; }
        public float Top { get; private set; }

        public FishTankGlass(float radius, float bottom, float top)
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
                x = x * Radius / norm;
                y = y * Radius / norm;
                z = z * Radius / norm;

                y = Math.Clamp(y, Bottom, Top);

                yield return (Gfx.float3(x, y, z), Gfx.float4(1f, 1f, 1f, 0.9f));
            }
        }
    }
}