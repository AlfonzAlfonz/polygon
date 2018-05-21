using Polygon.Unity.HeightMap.Model;
using UnityEngine;

namespace Polygon.Unity.HeightMap {
  public class CurveFilter : HeightMapFunction {

    public HeightMapFunction input;

    public AnimationCurve curve;

    public override float[,] GetHeightMap (int width, int height, UnityEngine.Vector2 offset) {
      var map = input.GetHeightMap(width, height, offset);
      var _curve = new AnimationCurve(curve.keys);

      for (int x = 0; x < width; x++) {
          for (int y = 0; y < height; y++) {
            map[x, y] = _curve.Evaluate(map[x,y]);
          }
        }

      return map;
    }
  }
}