using UnityEngine;

namespace Polygon.Unity {
  public static class FloatArrayExtender {
    public static Color[] ToHeightMapTexture (this float[, ] map) {
      var colors = new Color[map.GetLength (0) * map.GetLength (1)];

      for (int x = 0; x < map.GetLength (0); x++) {
        for (int y = 0; y < map.GetLength (1); y++) {
          colors[x * map.GetLength (1) + y] = Color.Lerp (Color.black, Color.white, map[x, y]);
        }
      }

      return colors;
    }
  }
}