using Polygon.Mesh;
using Polygon.Terrain;

namespace Polygon.Unity {
  struct MeshDataChunk {
    public Chunk chunk;
    public MeshData data;

    public MeshDataChunk(Chunk chunk, MeshData data){
      this.chunk = chunk;
      this.data = data;
    }
  }
}