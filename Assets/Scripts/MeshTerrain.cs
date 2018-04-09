using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Polygon;
using Polygon.Mesh;
using Polygon.Noise;
using Polygon.Terrain;
using Polygon.Terrain.Generators;
using Polygon.Thread;
using Polygon.Unity;
using UnityEngine;

public class MeshTerrain : MonoBehaviour {

  public int grid;

  MeshRenderer meshR;
  List<GameObject> objects;
  Map map;
  ChunkMapThread chunkRenderer;
  IMeshDataMapper mapper;

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
    mapper = new MeshDataMapper (this.transform, meshR.material);
    chunkRenderer = new ChunkMapThread (
      16,
      new ChunkGenerator (
        new MapGenerator (),
        new Noise (octaves)
      ),
      mapper
    );

    Debug.Log ("End awake");
  }

  // Use this for initialization
  void Start () {
    Debug.Log ("Start start");
    map = new Map (grid);
    chunkRenderer.Start ();

    for (int x = 0; x < 10; x++) {
      for (int z = 0; z < 10; z++) {
        for (int y = 0; y < 1; y++) {
          chunkRenderer.RenderChunk (new Vector3 (x, y, z));
        }
      }
    }
    Debug.Log ("End start");
  }

  void Update () {
    if (chunkRenderer.Results.Count != 0) {
      MeshDataChunk mc;
      lock (chunkRenderer.Results) {
        mc = chunkRenderer.Results.Dequeue ();
      }
      mapper.CreateObject (mc.data, mc.chunk);
    }
  }

  void OnApplicationQuit () {
    chunkRenderer.Stop ();
  }
}