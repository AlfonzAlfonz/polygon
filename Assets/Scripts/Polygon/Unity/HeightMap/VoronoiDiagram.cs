using System.Collections.Generic;
using Polygon.Noise;
using Polygon.Unity.HeightMap.Model;
using UnityEngine;

namespace Polygon.Unity.HeightMap {
  public class VoronoiDiagram : HeightMapFunction {

    public float frequency;

    public FastNoise.CellularReturnType returnType;

    public FastNoise.CellularDistanceFunction distanceFunction;

    public override float[, ] GetHeightMap (int width, int height, Vector2 offset) {
      var noise = new Voronoi (frequency, returnType, distanceFunction);

      return noise.HeigthMap (width, height, offset);
    }
  }
}