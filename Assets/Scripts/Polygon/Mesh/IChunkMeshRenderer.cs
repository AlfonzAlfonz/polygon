using Polygon.Mesh.Model;
using Polygon.Terrain;
using Polygon.Terrain.Model;

namespace Polygon.Mesh {
  public interface IChunkMeshRenderer {
    MeshData Map (Chunk chunk, float scale);
  }
}