using Polygon.Mesh.Model;
using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Mesh {
  public class PlaneMeshGenerator {

    public float Scale { get; set; }

    public PlaneMeshGenerator (float scale) {
      Scale = scale;
    }

    private Vector3 GetVector (float[, ] map, int x, int y) => new Vector3 (x, map[x, y] * 500 - 200, y);

    public MeshData CreateMesh (Chunk chunk) {
      MeshData mesh = new MeshData (chunk.Grid, chunk.Grid, 1);
      MeshPrimitives primitives = new MeshPrimitives (mesh);

      for (int x = 0; x < chunk.Grid; x++) {
        for (int y = 0; y < chunk.Grid; y++) {
          primitives.RenderTerrainQuad (
            GetVector (chunk.HeightMap, x, y),
            GetVector (chunk.HeightMap, x, y + 1),
            GetVector (chunk.HeightMap, x + 1, y),
            GetVector (chunk.HeightMap, x + 1, y + 1)
          );
        }
      }

      return mesh;
    }
  }
}