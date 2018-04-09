using Polygon.Mesh;
using Polygon.Terrain;
using UnityEngine;

namespace Polygon {
  public interface IMeshDataMapper {
    GameObject CreateObject (MeshData data, Chunk chunk);
  }
}