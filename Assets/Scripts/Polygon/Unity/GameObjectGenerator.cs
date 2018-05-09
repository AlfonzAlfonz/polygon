using Polygon.Mesh;
using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Unity
{
  public class GameObjectGenerator
  {
    PlaneMeshGenerator meshGenerator;
    Transform root;

    Material material;

    public UnityEngine.Mesh mesh;

    public GameObjectGenerator(PlaneMeshGenerator meshGenerator, Transform root, Material material)
    {
      this.meshGenerator = meshGenerator;
      this.root = root;
      this.material = material;
    }
    public void CreateGameObject(Chunk chunk)
    {
      var gameobj = new GameObject();
      gameobj.transform.name = "Chunk [" + chunk.Position.x + ";" + chunk.Position.y + "]";
      gameobj.transform.parent = root;
      gameobj.transform.position = new Vector3(chunk.AbsolutePosition.x, 0, chunk.AbsolutePosition.y);
      gameobj.AddComponent<MeshFilter>().mesh.LoadData(meshGenerator.CreateMesh(chunk));
      gameobj.AddComponent<MeshRenderer>().material = material;
    }
  }
}