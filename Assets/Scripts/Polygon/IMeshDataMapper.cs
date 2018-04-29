using Polygon.Mesh.Model;
using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon {
  public interface IMeshDataMapper {
    GameObject CreateObject (MeshData data, Chunk chunk);
  }
}