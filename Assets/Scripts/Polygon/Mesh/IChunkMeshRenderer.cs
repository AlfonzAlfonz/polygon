using Polygon.Terrain;

namespace Polygon.Mesh {
  public interface IChunkMeshRenderer {
    MeshData Map (Chunk chunk);
  }
}