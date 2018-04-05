using System;
using Polygon.Noise.Raw;
using UnityEngine;

namespace Polygon.Noise {
  static class Noise {
    public static float[, ] PerlinNoise (int width, int height, Vector2 offset, Octave[] octaves) {
      var map = new float[width, height];

      for (int x = 0; x < width; x++) {
        for (int y = 0; y < height; y++) {
          float value = 0;
          float divider = 0;

          for (int i = 0; i < octaves.Length; i++) {
            float frequency = octaves[i].frequency;
            float amplitude = octaves[i].amplitude;

            for (int j = 0; j < octaves[i].suboctaves; j++) {
              var pX = ((float) x + offset.x + octaves[0].offset.x) * (frequency / width);
              var pY = ((float) y + offset.y + octaves[0].offset.y) * (frequency / height);

              value += Mathf.PerlinNoise (pX, pY) * amplitude;
              divider += amplitude;

              frequency *= octaves[i].lacunarity;
              amplitude *= octaves[i].persistance;
            }

          }

          map[x, y] = value / divider;

        }
      }

      /*for (int x = 0; x < width; x++) {
        for (int y = 0; y < height; y++) {
          map[x, y] = Mathf.InverseLerp (minh, maxh, map[x, y]);
        }
      }*/

      return map;
    }
  }
}