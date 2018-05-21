using Polygon.Unity.HeightMap.Model;
using UnityEngine;

namespace Polygon.Unity.HeightMap {

  public class Roads : HeightMapFunction {

    public HeightMapFunction input;

    public override float[, ] GetHeightMap (int width, int height, UnityEngine.Vector2 offset) {
      var map = input.GetHeightMap (width, height, offset);
      var origin = new Vector2 (4, 3);
      var target = new Vector2 (5, 10);
      var steepness = .01f;

      float prev = map[5, 5];

      for (int x = 2; x < 4; x++) {
        for (int y = 0; y < 10; y++) {
          var val = map[x, y];

          map[x, y] = Mathf.Abs (val - prev) < steepness ?
            val :
            prev;

          prev = val;
        }
      }

      return map;
    }
  }
}