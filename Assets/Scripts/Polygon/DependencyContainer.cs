using Polygon.Mesh;
using Polygon.Noise;
using Polygon.Terrain;

namespace Polygon {
  public class DependencyContainer {
    public IMeshDataMapper MeshDataMapper { get; set; }
    public ChunkGenerator ChunkGenerator { get; set; }
    public Noise.Noise Noise { get; set; }
  }
}