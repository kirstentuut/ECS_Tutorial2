using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class PlayerMovementSystem : JobComponentSystem
{
    public struct PlayerInputJob : IJobProcessComponentData<Position, PlayerInput, Gravity>
    {

        public void Execute(ref Position position, ref PlayerInput playerInput, ref Gravity gravity)
        {
            position.Value.x += playerInput.Horizontal;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerInputJob{};

        return job.Schedule(this, 1, inputDeps);
    }
}
