using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polygon;
using Polygon.Mesh;
using Polygon.Noise;
using Polygon.Terrain;
using Polygon.Terrain.Generators;
using Polygon.Unity;
using UnityEngine;

public class MeshFactory : MonoBehaviour {

  MeshRenderer meshR;

  List<GameObject> objects;

  Map map;

  public int grid;

  Queue<MeshDataChunk> renderQueue;

  MeshDataMapper mapper;

  Octave[] octaves = new Octave[] {
    new Octave () {
    offset = new Vector2 (),
    frequency = 1f / 1000f,
    amplitude = 3f,
    suboctaves = 4,
    persistance = 1.3f,
    lacunarity = 1.6f
    },
    new Octave () {
    offset = new Vector2 (),
    frequency = 2f / 100f,
    amplitude = 1f,
    suboctaves = 4,
    persistance = 1.3f,
    lacunarity = 1.6f
    },
    new Octave () {
    offset = new Vector2 (),
    frequency = 5f / 10f,
    amplitude = .03f,
    suboctaves = 4,
    persistance = 1.3f,
    lacunarity = 1.6f
    },
    new Octave () {
    offset = new Vector2 (),
    frequency = 10f,
    amplitude = .03f,
    suboctaves = 1,
    },
  };

  void Awake () {
    Debug.Log ("Start awake");
    meshR = GetComponent<MeshRenderer> ();
    renderQueue = new Queue<MeshDataChunk> ();
    mapper = new MeshDataMapper (this.transform, meshR.material);
    Debug.Log ("End awake");
  }

  // Use this for initialization
  void Start () {
    Debug.Log ("Start start");
    map = new Map (grid, new MapGenerator (), new Noise (octaves));

    for (int x = 0; x < 10; x++) {
      for (int z = 0; z < 10; z++) {
        for (int y = 0; y < 1; y++) {
          AddAndRenderChunk (new Vector3 (x, y, z));
        }
      }
    }
    Debug.Log ("End start");
  }

  void AddAndRenderChunk (Vector3 position) {
    Task.Run (() => {
      Chunk chunk = map.AddChunk (position);
      MeshData data = mapper.GetMeshData (chunk);

      renderQueue.Enqueue (new MeshDataChunk (chunk, data));
    });
  }

  void Update () {
    if (renderQueue.Count != 0) {
      MeshDataChunk mc = renderQueue.Dequeue ();
      mapper.CreateObject (mc.data, mc.chunk);
    }
  }
}