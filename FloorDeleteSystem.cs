using Unity.Transforms;
//using Unity.Entities;
//using Unity.Mathematics;

//public class FloorDeleteSystem : ComponentSystem
//{
//    public struct PlayerGroup
//    {
//        public ComponentDataArray<Position> playerPosition;
//        public ComponentDataArray<PlayerInput> playerInput;
//        public readonly int Length;
//    }

//    public struct FloorGroup
//    {
//        public ComponentDataArray<Floor> floor;
//        public ComponentDataArray<Position> floorPosition;
//        public EntityArray entityArray;
//        public readonly int Length;
//    }

//    [Inject] PlayerGroup playerGroup;
//    [Inject] FloorGroup floorGroup;

//    protected override void OnUpdate()
//    {
//        for (int i = 0; i < floorGroup.Length; i++)
//        {
//            float dist = math.distance(playerGroup.playerPosition[0].Value, floorGroup.floorPosition[i].Value);

//            if(dist < 1)
//            {
//                PostUpdateCommands.DestroyEntity(floorGroup.entityArray[i]);
//            }
//        }
//    }
//}