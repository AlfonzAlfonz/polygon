using System.Threading.Tasks;
using Polygon.Mesh;
using Polygon.Mesh.Model;
using Polygon.Terrain.Model;
using Polygon.Unity;
using UnityEngine;

class ChunkObject : MonoBehaviour {

  public Chunk Chunk { get; set; }

  public Material Material { get; set; }

  public PlaneMeshGenerator MeshGenerator { get; set; }

  private MeshFilter filter;

  private Task<MeshData> renderTask { get; set; }

  public void Start () {
    filter = gameObject.AddComponent<MeshFilter> ();
    gameObject.AddComponent<MeshRenderer> ().material = Material;

  }

  public void Update () {
    if (Chunk.MakeTask != null && Chunk.MakeTask.IsCompleted) {
      Chunk.MakeTask = null;
      renderTask = MeshGenerator.CreateMesh (Chunk);
      renderTask.Start ();
    }
    
    if (renderTask != null && renderTask.IsCompleted) {
      filter.mesh.LoadData (renderTask.Result);
      renderTask = null;
    }

    if (renderTask != null && renderTask.IsFaulted) {
      var e = renderTask.Exception;
      renderTask = null;
      // throw new System.Exception("Error", e);
    }

    gameObject.SetActive (Chunk.Active);
  }
}