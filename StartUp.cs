using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using UnityEditor.Build.Player;
using Unity.Mathematics;

public class StartUp : MonoBehaviour {

    public Mesh PlayerMesh;
    public Material PlayerMaterial;

    public Mesh FloorMesh;
    public Material FloorMaterial;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void Start()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        var playerArchetype = entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(MeshInstanceRenderer),
            typeof(PlayerInput),
            typeof(Jump),
            typeof(Gravity)
        );

        var player = entityManager.CreateEntity(playerArchetype);

        entityManager.SetSharedComponentData(player, new MeshInstanceRenderer
        {
            mesh = PlayerMesh,
            material = PlayerMaterial,
        });


        var floorArchetype = entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(MeshInstanceRenderer),
            typeof(Floor)
        );
        for (int x = -10; x < 10; x++)
        {
            var floor = entityManager.CreateEntity(floorArchetype);

            entityManager.SetSharedComponentData(floor, new MeshInstanceRenderer
            {
                mesh = FloorMesh,
                material = FloorMaterial
            });

            entityManager.SetComponentData(floor, new Position { Value = new float3(x, -1, 0) });
        }

        entityManager.SetComponentData(player, new Position { Value = new float3(-9, 1, 0) });
    }

}
