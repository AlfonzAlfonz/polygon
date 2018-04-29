using Polygon.Mesh;
using Polygon.Noise;
using Polygon.Terrain;
using Polygon.Terrain.Generators;
using Polygon.Thread;
using UnityEngine;

namespace Polygon.Unity {
  public static class DependencyContainerExtender {
    public static void CreateForUnity (this DependencyContainer container, int grid, float scale, Transform parent, Material material, Octave[] octaves) {
      container.MeshDataMapper = new MeshDataMapper (parent, material, grid, scale);
      container.CubeMapper = new CubeMapper ();
      container.Noise = new Noise.Noise (octaves);
      container.ChunkMeshRenderer = new FlatMeshRenderer ();
      container.ChunkGenerator = new ChunkGenerator (container.CubeMapper, container.Noise);
      container.ChunkThread = new ChunkThread (grid,scale, container.ChunkGenerator, container.ChunkMeshRenderer);
    }
  }
}