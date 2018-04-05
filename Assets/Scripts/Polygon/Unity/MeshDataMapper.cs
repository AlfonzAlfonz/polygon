using System.Collections.Generic;
using Polygon.Mesh;
using Polygon.Terrain;
using UnityEngine;

namespace Polygon.Unity {
  class MeshDataMapper {
    public static List<GameObject> MapToScene (Map map, Transform parent, Material material) {
      var objects = new List<GameObject> ();
      foreach (Chunk chunk in map.Chunks) {
        var chunkMesh = new CubeMeshRenderer (chunk);
        var meshObject = new GameObject ("mesh");

        meshObject.transform.SetParent (parent);
        meshObject.transform.position = chunk.Position * 16;
        meshObject.AddComponent<MeshRenderer> ().material = material;

        var mesh = meshObject.AddComponent<MeshFilter> ().mesh;
        MeshDataToMesh (mesh, chunkMesh.Map ());
        meshObject.AddComponent<MeshCollider> ().sharedMesh = mesh;

        objects.Add (meshObject);
      }

      return objects;
    }

    public static void MeshDataToMesh (UnityEngine.Mesh mesh, MeshData data) {
      mesh.vertices = data.Vertices.ToArray ();
      mesh.triangles = data.Triangles.ToArray ();
      mesh.uv = data.UV.ToArray ();
    }
  }
}