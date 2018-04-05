using UnityEngine;

namespace Polygon.Mesh {
  class MeshPrimitives {

    public MeshData Mesh { get; set; }

    public MeshPrimitives (MeshData mesh) {
      Mesh = mesh;
    }

    public void RenderQuad(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4) {
      int vOffset = Mesh.Vertices.Count;
      AddQuadVertices (p1, p2, p3, p4);
      AddQuadTriangles (vOffset);
    }

    public void AddQuadVertices (Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4) {
      Mesh.Vertices.Add (p1);
      Mesh.Vertices.Add (p2);
      Mesh.Vertices.Add (p3);
      Mesh.Vertices.Add (p4);
    }

    public void AddQuadTriangles (int vOffset) {
      Mesh.Triangles.Add (vOffset);
      Mesh.Triangles.Add (vOffset + 1);
      Mesh.Triangles.Add (vOffset + 2);
      Mesh.Triangles.Add (vOffset + 3);
      Mesh.Triangles.Add (vOffset + 2);
      Mesh.Triangles.Add (vOffset + 1);
    }
  }
}