using System.Collections.Generic;
using Polygon.Terrain;
using UnityEngine;

namespace Polygon.Mesh {
  public class CubeMeshRenderer : IChunkMeshRenderer {

    public Chunk Chunk { get; set; }

    public MeshData Mesh { get; set; }

    MeshPrimitives primitives;

    public CubeMeshRenderer (Chunk chunk) {
      Chunk = chunk;
      Mesh = new MeshData (chunk.Cubes.GetLength (0), chunk.Cubes.GetLength (1), chunk.Cubes.GetLength (2));
      primitives = new MeshPrimitives(Mesh);
    }

    public MeshData Map () {
      for (int y = 0; y < Mesh.Height; y++) {
        for (int x = 0; x < Mesh.Width; x++) {
          for (int z = 0; z < Mesh.Depth; z++) {
            if (Chunk.Cubes[x, y, z] != null) {
              AddCube (x, y, z, ShouldRender (Chunk.Cubes, y, x, z));
            }
          }
        }
      }

      return Mesh;
    }

    void AddCube (int x, int y, int z, Surroundings s) {
      if (s.Down) {
        primitives.RenderQuad (new Vector3 (x, y, z), new Vector3 (x + 1, y, z), new Vector3 (x, y, z + 1), new Vector3 (x + 1, y, z + 1));
        AddUV2 ();
      }
      if (s.Up) {
        primitives.RenderQuad (new Vector3 (x, y + 1, z), new Vector3 (x, y + 1, z + 1), new Vector3 (x + 1, y + 1, z), new Vector3 (x + 1, y + 1, z + 1));
        AddUV1 ();
      }

      if (s.East) {
        primitives.RenderQuad (new Vector3 (x, y, z), new Vector3 (x, y + 1, z), new Vector3 (x + 1, y, z), new Vector3 (x + 1, y + 1, z));
        AddUV3 ();
      }
      if (s.West) {
        primitives.RenderQuad (new Vector3 (x, y, z + 1), new Vector3 (x + 1, y, z + 1), new Vector3 (x, y + 1, z + 1), new Vector3 (x + 1, y + 1, z + 1));
        AddUV3 ();
      }

      if (s.South) {
        primitives.RenderQuad (new Vector3 (x, y, z), new Vector3 (x, y, z + 1), new Vector3 (x, y + 1, z), new Vector3 (x, y + 1, z + 1));
        AddUV3 ();
      }
      if (s.North) {
        primitives.RenderQuad (new Vector3 (x + 1, y, z), new Vector3 (x + 1, y + 1, z), new Vector3 (x + 1, y, z + 1), new Vector3 (x + 1, y + 1, z + 1));
        AddUV3 ();
      }
    }

    void AddUV1 () {
      Mesh.UV.Add (new Vector2 (.25f, .25f));
      Mesh.UV.Add (new Vector2 (.25f, 0f));
      Mesh.UV.Add (new Vector2 (0f, .25f));
      Mesh.UV.Add (new Vector2 (0f, 0f));
    }

    void AddUV2 () {
      Mesh.UV.Add (new Vector2 (0.25f, 0.5f));
      Mesh.UV.Add (new Vector2 (0.25f, 0.25f));
      Mesh.UV.Add (new Vector2 (0f, 0.5f));
      Mesh.UV.Add (new Vector2 (0f, 0.25f));
    }

    void AddUV3 () {
      Mesh.UV.Add (new Vector2 (0.5f, 0.25f));
      Mesh.UV.Add (new Vector2 (0.5f, 0f));
      Mesh.UV.Add (new Vector2 (0.25f, 0.25f));
      Mesh.UV.Add (new Vector2 (0.25f, 0f));
    }

    Surroundings ShouldRender (Cube[, , ] cubes, int y, int x, int z) {
      Surroundings s = new Surroundings () {
        North = x == cubes.GetLength (0) - 1 || cubes[x + 1, y, z] == null,
        South = x == 0 || cubes[x - 1, y, z] == null,
        West = z == cubes.GetLength (2) - 1 || cubes[x, y, z + 1] == null,
        East = z == 0 || cubes[x, y, z - 1] == null,
        Up = y == cubes.GetLength (1) - 1 || cubes[x, y + 1, z] == null,
        Down = y == 0 || cubes[x, y - 1, z] == null
      };
      return s;
    }
  }
}