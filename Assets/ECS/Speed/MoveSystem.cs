using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Speed {
	public partial struct MoveSystem : ISystem {
		public void OnCreate(ref SystemState state) {
			float3 target = new float3(-10f, -10f, 0f);
			foreach (var (localTranform, speedComponent) in SystemAPI.Query<RefRW<LocalTransform>, SpeedComponent>()) {
				MoveJob job = new MoveJob(speedComponent.value, SystemAPI.Time.DeltaTime, target);
				job.ScheduleParallel();
			}
		}
		
		public void OnUpdate(ref SystemState state) {
			float3 target = new float3(-10f, -10f, 0f);
			new MoveJob(1f, SystemAPI.Time.DeltaTime, target).Schedule();

			//Entities.ForEach((ref LocalTransform transform, in SpeedComponent speed) => {
			//	transform.Position += new float3(0f, speed.value, 0f) * SystemAPI.Time.DeltaTime;
			//}).Run();
		}
	}
	
	public partial struct MoveJob : IJobEntity {
		private readonly float _speed;
		private readonly float _deltaTime;
		private readonly float3 _target;

		public MoveJob(float speed, float deltaTime, float3 target) : this() {
			_speed = speed;
			_deltaTime = deltaTime;
			_target = target;
		}
		
		public void Execute(RefRW<LocalTransform> localTransform) {
			float distance = math.distance(_target, localTransform.ValueRO.Position);
			while (distance > 0.5f) {
				localTransform.ValueRW.Position += new float3(0f, _speed, 0f) * _deltaTime;
				distance = math.distance(_target, localTransform.ValueRO.Position);
			}
		}
	}
}