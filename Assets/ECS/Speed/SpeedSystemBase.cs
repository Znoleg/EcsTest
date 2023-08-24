using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Speed {
    public partial class SpeedSystemBase : SystemBase {
        protected override void OnUpdate() {
            Entities.ForEach((ref LocalTransform transform, in SpeedComponent speed) => {
                transform.Position += new float3(0f, speed.value, 0f) * SystemAPI.Time.DeltaTime;
            }).Run();
        }
    }
}
