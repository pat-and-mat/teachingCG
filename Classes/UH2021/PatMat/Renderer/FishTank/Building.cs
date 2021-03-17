using System;
using System.Collections;
using System.Collections.Generic;
using GMath;
using Renderer.CGraphics;
using Rendering;
using static Renderer.CGraphics.Utils;

namespace Renderer.FishTank
{
    class Building : Model
    {
        public float ScaleX { get; private set; }
        public float ScaleY { get; private set; }
        public float ScaleZ { get; private set; }

        public Building(float scaleX, float scaleY, float scaleZ)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            ScaleZ = scaleZ;
        }

        public override IEnumerable<(float3, float4)> Samples(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var turnIntoBoxMatrix = Gfx.float4x4(
                0.5f, 0, 0, 0,
                0, 0.5f, 0, 0,
                0, 0, 0.5f, 0,
                0.5f, 0.5f, 0.5f, 1
                );
                var p = ApplyTransform(Gfx.randomInBox(), Transforms.Scale(ScaleX, ScaleY, ScaleZ));
                p = ApplyTransform(p, turnIntoBoxMatrix);

                yield return (p, Gfx.float4(1f, 1f, 1f, 0.9f));
            }
        }
    }
}