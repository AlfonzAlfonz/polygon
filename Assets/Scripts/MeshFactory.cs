using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Polygon;
using Polygon.Mesh;
using Polygon.Terrain;
using Polygon.Unity;
using UnityEngine;

public class MeshFactory : MonoBehaviour {

  MeshRenderer meshR;

  List<GameObject> objects;

  Map map;

  void Awake () {
    meshR = GetComponent<MeshRenderer> ();
    //meshR.material.mainTexture.filterMode = FilterMode.Point;
    //meshR.material.mainTexture.wrapMode = TextureWrapMode.Clamp;

  }

  // Use this for initialization
  void Start () {
    map = new Map ();
    objects = MeshDataMapper.MapToScene (map, this.transform, meshR.material);
  }

  /*private void OnDrawGizmos () {
    if (chunk == null) {
      return;
    }
    Gizmos.color = Color.red;
    for (int i = 0; i < mesh.vertices.Length; i++) {
      Gizmos.DrawSphere (chunk.Mesh.Vertices[i], 0.1f);
    }
  }*/
}