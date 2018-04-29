using System;
using System.Collections.Generic;
using System.Threading;
using Polygon.Mesh;
using Polygon.Mesh.Model;
using Polygon.Terrain;
using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Thread {
  public class ChunkThread {

    ChunkGenerator generator;

    IChunkMeshRenderer renderer;

    System.Threading.Thread thread;

    Queue<Vector3> tasks;

    int grid;
    float scale;

    public Queue<MeshDataChunk> Results { get; private set; }

    public ChunkThread (int grid, float scale, ChunkGenerator generator, IChunkMeshRenderer renderer) {
      this.generator = generator;
      this.renderer = renderer;
      this.grid = grid;
      this.scale = scale;
      Results = new Queue<MeshDataChunk> ();
      tasks = new Queue<Vector3> ();
      thread = new System.Threading.Thread (ThreadMethod);
    }

    public void Start () {
      thread.Start ();
    }

    public void Stop () {
      thread.Abort ();
    }

    public void RenderChunk (Vector3 position) {
      lock (tasks) {
        tasks.Enqueue (position);
      }
    }

    void ThreadMethod () {
      while (true) {
        if (tasks.Count > 0) {
          Vector3 task;
          lock (tasks) {
            task = tasks.Dequeue ();
          }
          Chunk chunk = generator.CreateChunk (grid, task);
          MeshData data = renderer.Map (chunk, scale);

          Results.Enqueue (new MeshDataChunk (chunk, data));
          GC.Collect();
        }

        System.Threading.Thread.Sleep (1);
      }
    }
  }
}