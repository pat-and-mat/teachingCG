using GMath;
using Rendering;
using System;
using System.Linq;
using static GMath.Gfx;
using static Renderer.CGraphics.Utils;

namespace Renderer
{
    class Program
    {
        static void Main(string[] args)
        {
            Raster render = new Raster(1024, 512);
            RenderFishTank(render);
            render.RenderTarget.Save("fish-tank.rbm");
            Console.WriteLine("Done.");
        }

        public static void RenderFishTank(Raster render)
        {
            render.ClearRT(float4(0, 0, 0f, 1)); // clear with color dark blue.

            var coloredPoints = new Renderer.FishTank.FishTank(2.5f).Samples(100000).ToArray();
            var points = coloredPoints.Select(cp => cp.Item1).ToArray();
            var colors = coloredPoints.Select(cp => cp.Item2).ToArray();

            #region viewing and projecting

            points = ApplyTransform(points, Transforms.LookAtLH(float3(5f, 2.6f, 4), float3(0, 0, 0), float3(0, 1, 0)));
            points = ApplyTransform(points, Transforms.PerspectiveFovLH(pi_over_4, render.RenderTarget.Height / (float)render.RenderTarget.Width, 0.01f, 10));

            #endregion

            render.DrawPoints(points, colors);
        }
    }
}
