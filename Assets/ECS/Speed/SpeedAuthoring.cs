using Unity.Entities;
using UnityEngine;

namespace ECS.Speed {
    public class SpeedAuthoring : MonoBehaviour {
        public float value;
    }

    public class SpeedBaker : Baker<SpeedAuthoring> {
        public override void Bake(SpeedAuthoring authoring) {
            Entity entity = GetEntity(authoring, TransformUsageFlags.NonUniformScale | TransformUsageFlags.Dynamic);
            AddComponent(entity, new SpeedComponent() {value = 56f});
        }
    }
}