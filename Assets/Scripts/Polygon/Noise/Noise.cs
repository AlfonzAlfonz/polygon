using System;
using Polygon.Noise.Raw;
using UnityEngine;

namespace Polygon.Noise {
  public class Noise {

    public Octave[] Octaves { get; set; }

    public Noise (Octave[] octaves) {
      Octaves = octaves;
    }
    public float[, ] PerlinNoise (int width, int height, Vector2 offset) {
      var map = new float[width, height];

      for (int x = 0; x < width; x++) {
        for (int y = 0; y < height; y++) {
          float value = 0;
          float divider = 0;

          for (int i = 0; i < Octaves.Length; i++) {
            float frequency = Octaves[i].frequency;
            float amplitude = Octaves[i].amplitude;

            for (int j = 0; j < Octaves[i].suboctaves; j++) {
              var pX = ((float) x + offset.x + Octaves[0].offset.x) * (frequency / width);
              var pY = ((float) y + offset.y + Octaves[0].offset.y) * (frequency / height);

              value += Mathf.PerlinNoise (pX, pY) * amplitude;
              divider += amplitude;

              frequency *= Octaves[i].lacunarity;
              amplitude *= Octaves[i].persistance;
            }

          }

          map[x, y] = value / divider;

        }
      }

      return map;
    }
  }
}