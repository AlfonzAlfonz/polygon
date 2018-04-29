using System.Collections.Generic;
using Polygon.Mesh.Model;
using Polygon.Terrain;
using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Mesh {
  public class FlatMeshRenderer : IChunkMeshRenderer {

    public Chunk Chunk { get; set; }

    public MeshData Mesh { get; set; }

    public float Scale { get; set; }

    MeshPrimitives primitives;

    public FlatMeshRenderer () {

    }

    public MeshData Map (Chunk chunk, float scale) {
      Scale = scale;
      Chunk = chunk;
      Mesh = new MeshData (chunk.Cubes.GetLength (0), chunk.Cubes.GetLength (1), chunk.Cubes.GetLength (2));
      primitives = new MeshPrimitives (Mesh);

      for (int y = 0; y < Mesh.Height; y++) {
        for (int x = 0; x < Mesh.Width; x++) {
          for (int z = 0; z < Mesh.Depth; z++) {
            if (Chunk.Cubes[x, y, z] != null) {
              AddCube (x, y, z, ShouldRender (Chunk.Cubes, y, x, z), Chunk.Cubes[x, y, z], Scale);
            }
          }
        }
      }

      return Mesh;
    }
    void AddCube (float x, float y, float z, Surroundings s, Cube c, float scale) {
      if (s.Down) {
        primitives.RenderQuad (new Vector3 (x, y, z), new Vector3 (x + 1, y, z), new Vector3 (x, y, z + 1), new Vector3 (x + 1, y, z + 1));
        //AddUV2 ();
      }
      if (s.Up) {
        primitives.RenderTerrainQuad (
          new Vector3 (x, y + c.Dimensions.top1.y, z) * scale,
          new Vector3 (x, y + c.Dimensions.top3.y, z + 1) * scale,
          new Vector3 (x + 1, y + c.Dimensions.top2.y, z) * scale,
          new Vector3 (x + 1, y + c.Dimensions.top4.y, z + 1) * scale
        );
        //AddUV1 ();
      }

      if (s.East) {
        primitives.RenderQuad (
          new Vector3 (x, y, z) * scale,
          new Vector3 (x, y + c.Dimensions.top1.y, z) * scale,
          new Vector3 (x + 1, y, z) * scale,
          new Vector3 (x + 1, y + c.Dimensions.top2.y, z) * scale
        );
        //AddUV3 ();
      }
      if (s.West) {
        primitives.RenderQuad (
          new Vector3 (x, y, z + 1) * scale,
          new Vector3 (x + 1, y, z + 1) * scale,
          new Vector3 (x, y + c.Dimensions.top3.y, z + 1) * scale,
          new Vector3 (x + 1, y + c.Dimensions.top4.y, z + 1) * scale
        );
        //AddUV3 ();
      }

      if (s.South) {
        primitives.RenderQuad (
          new Vector3 (x, y, z) * scale,
          new Vector3 (x, y, z + 1) * scale,
          new Vector3 (x, y + c.Dimensions.top1.y, z) * scale,
          new Vector3 (x, y + c.Dimensions.top3.y, z + 1) * scale
        );
        //AddUV3 ();
      }
      if (s.North) {
        primitives.RenderQuad (
          new Vector3 (x + 1, y, z) * scale,
          new Vector3 (x + 1, y + c.Dimensions.top2.y, z) * scale,
          new Vector3 (x + 1, y, z + 1) * scale,
          new Vector3 (x + 1, y + c.Dimensions.top4.y, z + 1) * scale
        );
        //AddUV3 ();
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
        North = x == cubes.GetLength (0) - 1 || cubes[x + 1, y, z] == null || cubes[x + 1, y, z].Dimensions.top2.y != 1 || cubes[x + 1, y, z].Dimensions.top4.y != 1,
        South = x == 0 || cubes[x - 1, y, z] == null || cubes[x - 1, y, z].Dimensions.top1.y != 1 || cubes[x - 1, y, z].Dimensions.top3.y != 1,
        West = z == cubes.GetLength (2) - 1 || cubes[x, y, z + 1] == null || cubes[x, y, z + 1].Dimensions.top3.y != 1 || cubes[x, y, z + 1].Dimensions.top4.y != 1,
        East = z == 0 || cubes[x, y, z - 1] == null || cubes[x, y, z - 1].Dimensions.top1.y != 1 || cubes[x, y, z - 1].Dimensions.top2.y != 1,
        Up = y == cubes.GetLength (1) - 1 || cubes[x, y + 1, z] == null,
        Down = y == 0 || cubes[x, y - 1, z] == null
      };
      return s;
    }
  }
}