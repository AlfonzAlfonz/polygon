using Polygon.Mesh;
using UnityEngine;

namespace Polygon.Terrain {
  public interface IMeshDataMapper {
    MeshData GetMeshData (Chunk chunk);
    GameObject CreateObject (MeshData data, Chunk chunk);
  }
}