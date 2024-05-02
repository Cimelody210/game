using System;
using System.IO;
using System.Collection;
using System.Collection.LowLevel.Unsafe;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace EntityCommandBuffer: MonoBahaviour
{
    [NativeContainer]
    public struct EntityCommandBuffer: IDispose
    {
        public bool Icreated{get;}
        public int min_Chunksize{get; set;}
        public bool should_playback{get; set;}
        
        public DynamicBuffer<T> AddBuffer<T>(Entity e) where T: struct, IBufferElementData;
        public void AddComponent(EntityQuery entityquery, ComponentType componentype);
        public void DisPose();
        public Playback(EntityManager mgr);
        public Playback(ExclusiveEntityTransaction eet);
        public void RemoveComponent<T>(Entity e);
        public void SetSharedComponent<T> AddBuffer<T>(Entity e) where T: struct, IBufferElementData;
        public void DestroyEntity(Entity e);
        public void DestroyEntity(EntityQuery eq);
        public Entity Instantiate(Entity e);

        [NativeContainer]
        [NativeContainerIsAtomicWriteOnly]
        public struct Concurrent
        {
            public DynamicBuffer<T> AddBuffer(int jobId, Entity e) where T: struct, IBufferElementData;
        }
    }
    void Start()
    {

    }
    void Update()
    {

    }
}