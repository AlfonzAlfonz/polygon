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

  // Config
  public int grid;
  public float scale;
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
  };

  MeshRenderer meshR;
  Map map;

  DependencyContainer container;

  void Awake () {
    Debug.Log ("Start awake");
    meshR = GetComponent<MeshRenderer> ();
    map = new Map (grid);
    container = new DependencyContainer ();
    container.CreateForUnity (grid, scale, this.transform, meshR.material, octaves);

    Debug.Log ("End awake");
  }

  // Use this for initialization
  void Start () {
    Debug.Log ("Start start");
    container.ChunkThread.Start ();

    for (int x = 0; x < 20; x++) {
      for (int z = 0; z < 20; z++) {
        for (int y = 0; y < 1; y++) {
          container.ChunkThread.RenderChunk (new Vector3 (x, y, z));
        }
      }
    }
    Debug.Log ("End start");
  }

  void Update () {
    if (container.ChunkThread.Results.Count != 0) {
      MeshDataChunk mc;
      lock (container.ChunkThread.Results) {
        mc = container.ChunkThread.Results.Dequeue ();
      }
      container.MeshDataMapper.CreateObject (mc.data, mc.chunk);
    }
  }

  void OnApplicationQuit () {
    container.ChunkThread.Stop ();
  }
}