using System;
using System.Collections;
using System.Collections.Generic;
using GMath;
using Rendering;
using Renderer.CGraphics;
using static Renderer.CGraphics.Utils;

namespace Renderer.FishTank
{
    class FishTank : Model
    {
        public FishTankGlass FishTankGlass { get; private set; }
        public Lake Lake { get; private set; }
        public Building Building1 { get; private set; }
        public Building Building2 { get; private set; }
        public Building Building3 { get; private set; }
        public Building Building4 { get; private set; }
        public Building Building5 { get; private set; }

        public FishTank(float radius)
        {
            FishTankGlass = new FishTankGlass(radius, -7 * radius / 8, 3 * radius / 4);
            Lake = new Lake(radius, -7 * radius / 8, -radius / 5);

            Building1 = new Building(0.2f, 1.4f, 0.6f);
            Building2 = new Building(0.3f, 0.2f, 0.3f);
            Building3 = new Building(0.3f, 1.9f, 0.1f);
            Building4 = new Building(0.4f, 1.7f, 0.7f);
            Building5 = new Building(0.2f, 2.3f, 0.6f);
        }

        public override IEnumerable<(float3, float4)> Samples(int n)
        {
            foreach (var p in FishTankGlass.Samples(n))
                yield return p;
            foreach (var p in Lake.Samples(3 * n))
                yield return p;

            foreach (var cp in Building1.Samples(5 * n))
            {
                var p = cp.Item1;
                var c = cp.Item2;

                var transform = Gfx.mul(
                    Transforms.Translate(0.2f, -0.7f, 0.2f),
                    Transforms.RotateRespectTo(
                        Gfx.float3(0, 0, 0),
                        Gfx.float3(-0.2f, 0, 0.4f),
                        Gfx.pi / 6
                    )
                );
                p = ApplyTransform(p, transform);

                yield return (p, c);
            }

            foreach (var cp in Building2.Samples(5 * n))
            {
                var p = cp.Item1;
                var c = cp.Item2;

                var transform = Gfx.mul(
                    Transforms.Translate(1f, -0.7f, 1f),
                    Transforms.RotateRespectTo(
                        Gfx.float3(0, 0, 0),
                        Gfx.float3(-0.2f, 0, 0.4f),
                        Gfx.pi / 6
                    )
                );
                p = ApplyTransform(p, transform);

                yield return (p, c);
            }

            foreach (var cp in Building3.Samples(5 * n))
            {
                var p = cp.Item1;
                var c = cp.Item2;

                var transform = Gfx.mul(
                    Transforms.Translate(1.5f, -0.7f, -1f),
                    Transforms.RotateRespectTo(
                        Gfx.float3(0, 0, 0),
                        Gfx.float3(-0.2f, 0, 0.4f),
                        Gfx.pi / 6
                    )
                );
                p = ApplyTransform(p, transform);

                yield return (p, c);
            }

            foreach (var cp in Building4.Samples(5 * n))
            {
                var p = cp.Item1;
                var c = cp.Item2;

                var transform = Gfx.mul(
                    Transforms.Translate(1.2f, -0.7f, -0.4f),
                    Transforms.RotateRespectTo(
                        Gfx.float3(0, 0, 0),
                        Gfx.float3(-0.2f, 0.2f, 0.4f),
                        Gfx.pi / 6
                    )
                );
                p = ApplyTransform(p, transform);

                yield return (p, c);
            }

            foreach (var cp in Building5.Samples(5 * n))
            {
                var p = cp.Item1;
                var c = cp.Item2;

                var transform = Gfx.mul(
                    Transforms.Translate(0.3f, -0.7f, 1.3f),
                    Transforms.RotateRespectTo(
                        Gfx.float3(0, 0, 0),
                        Gfx.float3(-0.2f, 0, 0.4f),
                        Gfx.pi / 6
                    )
                );
                p = ApplyTransform(p, transform);

                yield return (p, c);
            }
        }
    }
}