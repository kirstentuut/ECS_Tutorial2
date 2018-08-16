//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Entities;
//using Unity.Jobs;

//public class MovementSystem : JobComponentSystem 
//{
//    public struct PlayerInputJob : IJobProcessComponentData<PlayerInput>
//    {
//        public float Horizontal;
//        public float Vertical;

//        public void Execute(ref PlayerInput input)
//        {
//            input.Horizontal = Horizontal;
//            input.Vertical = Vertical;
//        }
//    }

//    protected override JobHandle OnUpdate(JobHandle inputDeps)
//    {
//        var job = new PlayerInputJob
//        {
//            Horizontal = Input.GetAxis("Horizontal"),
//            Vertical = Input.GetAxis("Vertical")
//        };

//        return job.Schedule(this, 1, inputDeps);
//    }

//    //public struct PlayerGroup
//    //{
//    //    public ComponentDataArray<Position> playerPosition;
//    //    public ComponentDataArray<PlayerInput> playerInput;
//    //    public readonly int Length;
//    //}

//    //[Inject] PlayerGroup playerGroup;

//    //protected override void OnUpdate()
//    //{

//    //    for (int i = 0; i < playerGroup.Length; i++)
//    //    {
//    //        var newPosition = playerGroup.playerPosition[i];
//    //        newPosition.Value.x += Input.GetAxis("Horizontal") *5*Time.deltaTime;
//    //        newPosition.Value.y += Input.GetAxis("Vertical") *5*Time.deltaTime;
//    //        playerGroup.playerPosition[i] = newPosition;
//    //    }
//    //}
//}
