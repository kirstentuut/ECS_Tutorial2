using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class JumpSystem : JobComponentSystem
{
    private struct JumpJob : IJobProcessComponentData<Position, Jump, Gravity>
    {
        public float dt;
        public bool JumpUp;


        public void Execute(ref Position position, ref Jump jump, ref Gravity gravity)
        {
            if (position.Value.y > 0 && gravity.JumpTime <= 0)
            {
                position.Value.y += -0.1f;
                Debug.Log("y position : " + position.Value.y);
            }

            if (JumpUp && gravity.JumpTime <= 0 && position.Value.y <= 0f)
            {
                gravity.JumpTime = 20;
                Debug.Log("JumpTime is:" + gravity.JumpTime);
            }

            if (gravity.JumpTime > 0)
            {
                position.Value.y += 0.1f;
                position.Value.x += 0.03f;
                gravity.JumpTime--;
                Debug.Log("Jump position : " + position.Value.y + "Jumptime : " + gravity.JumpTime);
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new JumpJob
        {
            dt = Time.deltaTime,
            JumpUp = Input.GetKey(KeyCode.UpArrow)
        };

        return job.Schedule(this, 1, inputDeps);
    }
}