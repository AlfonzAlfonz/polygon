using System.Collections.Generic;
using Polygon.Noise;
using Polygon.Unity.HeightMap.Model;
using UnityEngine;

namespace Polygon.Unity.HeightMap {
  public class VoronoiDiagram : HeightMapFunction {
    public Vector2 offset;

    public float frequency;

    public FastNoise.CellularReturnType returnType;

    public override float[, ] GetHeightMap (int width, int height) {
      var noise = new Voronoi (frequency, returnType);

      return noise.HeigthMap (width, height, offset);
    }
  }
}