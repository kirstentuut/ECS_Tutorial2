using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

public class PlayerInputSystem : JobComponentSystem
{
    public struct PlayerInputJob : IJobProcessComponentData<PlayerInput>
    {
        public bool Left;
        public bool Right;

        public void Execute(ref PlayerInput input)
        {
            input.Horizontal = Left ? -1f : Right ? 1f : 0f;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerInputJob
        {
            Left = Input.GetKey(KeyCode.LeftArrow),
            Right = Input.GetKey(KeyCode.RightArrow),

        };

        return job.Schedule(this, 1, inputDeps);
    }

}
