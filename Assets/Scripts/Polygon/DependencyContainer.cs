using Polygon.Mesh;
using Polygon.Noise;
using Polygon.Terrain;
using Polygon.Terrain.Generators;
using Polygon.Thread;

namespace Polygon {
  public class DependencyContainer {
    public IMeshDataMapper MeshDataMapper { get; set; }
    public ChunkGenerator ChunkGenerator { get; set; }
    public CubeMapper CubeMapper { get; set; }
    public Noise.Noise Noise { get; set; }

    public IChunkMeshRenderer ChunkMeshRenderer { get; set; }
    public ChunkThread ChunkThread { get; set; }
  }
}