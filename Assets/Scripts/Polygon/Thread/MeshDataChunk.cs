using Polygon.Mesh;
using Polygon.Mesh.Model;
using Polygon.Terrain.Model;

namespace Polygon.Thread {
  public struct MeshDataChunk {
    public Chunk chunk;
    public MeshData data;

    public MeshDataChunk(Chunk chunk, MeshData data){
      this.chunk = chunk;
      this.data = data;
    }
  }
}