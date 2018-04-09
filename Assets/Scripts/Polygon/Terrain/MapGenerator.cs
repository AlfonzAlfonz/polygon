using UnityEngine;

namespace Polygon.Terrain {
  public class CubeMapper {
    public Cube[, , ] Generate (float[, ] noisemap, Chunk chunk) {
      var cubes = new Cube[noisemap.GetLength (0) - 1, 300, noisemap.GetLength (1) - 1];

      for (int x = 0; x < cubes.GetLength (0); x++) {
        for (int z = 0; z < cubes.GetLength (2); z++) {
          var h = (int) Mathf.Floor (GetHeight (noisemap, x, z));
          for (int y = 0; y < h + 1; y++) {
            var cube = cubes[x, y, z] = new Cube (chunk);

            if (y == h) {
              cube.Dimensions = GetDimensions (noisemap, x, z, h);
            }
          }
        }
      }

      return cubes;
    }

    private float Accelerate (float value) {
      return value * 300f - 100;
    }

    private float GetHeight (float[, ] noisemap, int x, int z) {
      return Accelerate ((noisemap[x, z] + noisemap[x + 1, z] + noisemap[x, z + 1] + noisemap[x + 1, z + 1]) / 4);
    }

    private Vector3 GetPoint (float value, int h) {
      var dim = Accelerate (value) - h;
      if (dim > 1) {
        dim = 1;
      } else if (dim < 0) {
        dim = 0;
      }
      return new Vector3 (0, dim, 0);
    }

    private Dimensions GetDimensions (float[, ] noisemap, int x, int z, int h) {
      return new Dimensions () {
        top1 = GetPoint (noisemap[x, z], h),
          top2 = GetPoint (noisemap[x + 1, z], h),
          top3 = GetPoint (noisemap[x, z + 1], h),
          top4 = GetPoint (noisemap[x + 1, z + 1], h)
      };
    }
  }
}