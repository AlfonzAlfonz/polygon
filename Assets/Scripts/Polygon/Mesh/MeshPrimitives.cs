using Polygon.Terrain;
using UnityEngine;

namespace Polygon.Mesh {
  class MeshPrimitives {

    public MeshData Mesh { get; set; }

    public MeshPrimitives (MeshData mesh) {
      Mesh = mesh;
    }

    public void RenderQuad (Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4) {
      int vOffset = Mesh.Vertices.Count;
      AddTriangleVertices (p1, p2, p3);
      AddTriangleTriangles (vOffset);

      vOffset = Mesh.Vertices.Count;
      AddTriangleVertices (p4, p3, p2);
      AddTriangleTriangles (vOffset);
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

    public void RenderTerrainQuad (Dimensions dimensions) {

    }

    public void AddTerrainQuadVertices (Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4) {
      Mesh.Vertices.Add (p1);
      Mesh.Vertices.Add (p2);
      Mesh.Vertices.Add (p3);
      Mesh.Vertices.Add (p4);
    }

    public void AddTerrainQuadTriangles (int vOffset) {
      Mesh.Triangles.Add (vOffset);
      Mesh.Triangles.Add (vOffset + 1);
      Mesh.Triangles.Add (vOffset + 2);
      Mesh.Triangles.Add (vOffset + 3);
      Mesh.Triangles.Add (vOffset + 2);
      Mesh.Triangles.Add (vOffset + 1);
    }

    public void RenderTriangle (Vector3 p1, Vector3 p2, Vector3 p3) {
      int vOffset = Mesh.Vertices.Count;
      AddTriangleVertices (p1, p2, p3);
      AddTriangleTriangles (vOffset);
    }

    public void AddTriangleVertices (Vector3 p1, Vector3 p2, Vector3 p3) {
      Mesh.Vertices.Add (p1);
      Mesh.Vertices.Add (p2);
      Mesh.Vertices.Add (p3);
    }

    public void AddTriangleTriangles (int vOffset) {
      Mesh.Triangles.Add (vOffset);
      Mesh.Triangles.Add (vOffset + 1);
      Mesh.Triangles.Add (vOffset + 2);
    }
  }
}