using Polygon.Mesh;

namespace Polygon.Unity {
  public static class MeshExtender {
    public static UnityEngine.Mesh LoadData (this UnityEngine.Mesh mesh, MeshData data) {
      mesh.vertices = data.Vertices.ToArray ();
      mesh.triangles = data.Triangles.ToArray ();
      mesh.uv = data.UV.ToArray ();

      mesh.RecalculateNormals ();

      return mesh;
    }
  }
}