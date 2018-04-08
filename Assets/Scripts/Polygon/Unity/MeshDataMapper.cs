using System.Collections.Generic;
using System.Threading.Tasks;
using Polygon.Mesh;
using Polygon.Terrain;
using UnityEngine;

namespace Polygon.Unity {
  class MeshDataMapper : IMeshDataMapper {

    public Transform Parent { get; set; }

    public Material Material { get; set; }

    public MeshDataMapper (Transform parent, Material material) {
      Parent = parent;
      Material = material;
    }

    public MeshData GetMeshData(Chunk chunk) {
      var chunkMesh = new CubeMeshRenderer (chunk);

      return chunkMesh.Map();
    }

    public GameObject CreateObject(MeshData data, Chunk chunk) {
      var chunkObject = new GameObject ("mesh");

      chunkObject.transform.SetParent (Parent);
      chunkObject.transform.position = chunk.Position * 16;

      chunkObject.AddComponent<MeshRenderer> ().material = Material;

      var mesh = chunkObject.AddComponent<MeshFilter> ().mesh.LoadData(data);
      chunkObject.AddComponent<MeshCollider> ().sharedMesh = mesh;

      return chunkObject;
    }
  }
}