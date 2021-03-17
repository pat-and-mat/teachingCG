using System;
using GMath;
using static GMath.Gfx;

namespace Renderer.CGraphics
{
    public static class Utils
    {
        public static float3 ApplyTransform(float3 point, float4x4 matrix)
        {
            float4 h = float4(point, 1);
            h = mul(h, matrix);
            return h.xyz / h.w;
        }

        public static float3[] ApplyTransform(float3[] points, float4x4 matrix)
        {
            float3[] result = new float3[points.Length];

            // Transform points with a matrix
            // Linear transform in homogeneous coordinates
            for (int i = 0; i < points.Length; i++)
                result[i] = ApplyTransform(points[i], matrix);

            return result;
        }


        public static float3[] ApplyTransform(float3[] points, Func<float3, float3> freeTransform)
        {
            float3[] result = new float3[points.Length];

            // Transform points with a function
            for (int i = 0; i < points.Length; i++)
                result[i] = freeTransform(points[i]);

            return result;
        }
    }
}