using System;
using UnityEngine;
using static FastNoise;

namespace Polygon.Noise {
  public class Voronoi {

    public float Frequency { get; set; }

    public CellularReturnType ReturnType { get; set; }

    public Voronoi (float frequency, CellularReturnType returnType) { 
      Frequency = frequency;
      ReturnType = returnType;
    }

    public float[, ] HeigthMap (int width, int height, Vector2 offset) {
      var map = new float[width, height];

      var noise = new FastNoise ();
      noise.SetNoiseType (FastNoise.NoiseType.Cellular);
      noise.SetFrequency (.02f);
      noise.SetCellularReturnType (CellularReturnType.CellValue);

      for (int x = 0; x < width; x++) {
        for (int y = 0; y < height; y++) {
          map[x, y] = noise.GetNoise (x + offset.x, y + offset.y);
        }
      }

      return map;
    }
  }
}