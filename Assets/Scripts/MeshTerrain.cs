using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Polygon;
using Polygon.Mesh;
using Polygon.Noise;
using Polygon.Terrain;
using Polygon.Terrain.Model;
using Polygon.Unity;
using UnityEngine;

public class MeshTerrain : MonoBehaviour {

  public int grid;
  public float scale;

  public Transform player;

  public Material material;

  public Mesh mesh;

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
    amplitude = 5f,
    suboctaves = 4,
    persistance = 1.3f,
    lacunarity = 1.6f
    }
  };

  MeshRenderer meshR;
  DependencyContainer container;

  Map map;
  ChunkGenerator generator;

  GameObjectGenerator gameObjectGenerator;

  void Awake () {
    generator = new ChunkGenerator(new QuadMapper(), new Noise(octaves));
    gameObjectGenerator = new GameObjectGenerator(new PlaneMeshGenerator(scale), this.transform, material);
    gameObjectGenerator.mesh = mesh;
    map = new Map(grid, 20, generator, gameObjectGenerator);
    map.player = player;
  }

  void Start () {
    GC.Collect();

  }

  void Update () {
    map.Update();
  }

  void OnApplicationQuit () {
  }
}