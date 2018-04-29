using System.Collections.Generic;
using Polygon.Mesh;
using Polygon.Mesh.Model;
using Polygon.Terrain;
using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Unity {
  class MeshDataMapper : IMeshDataMapper {

    public Transform Parent { get; set; }

    public Material Material { get; set; }

    public IChunkMeshRenderer Renderer { get; set; }

    public int Grid { get; set; }

    public float Scale { get; set; }

    public MeshDataMapper (Transform parent, Material material, int grid, float scale) {
      Parent = parent;
      Material = material;
      Grid = grid;
      Scale = scale;
    }

    public GameObject CreateObject (MeshData data, Chunk chunk) {
      var chunkObject = new GameObject ("mesh");

      chunkObject.transform.SetParent (Parent);
      chunkObject.transform.position = chunk.Position * Grid * Scale;

      chunkObject.AddComponent<MeshRenderer> ().material = Material;

      var mesh = chunkObject.AddComponent<MeshFilter> ().mesh.LoadData (data);
      //chunkObject.AddComponent<MeshCollider> (). = mesh;

      return chunkObject;
    }
  }
}