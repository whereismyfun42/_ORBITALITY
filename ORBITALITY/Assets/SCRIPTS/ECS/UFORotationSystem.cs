using Unity.Jobs;
using Unity.Collections;
using Unity.Transforms;
using Unity.Burst;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class UFORotationSystem : JobComponentSystem
{
    [BurstCompile]
    private struct UFOControlJob : IJobForEach<UFORotationData, Rotation, Translation>
    {
        public float xMinRange;
        public float xMaxRange;
        public float yMinRange;
        public float yMaxRange;
        public float zMinRange;
        public float zMaxRange;
        public float deltaTime;

        public void Execute(ref UFORotationData UFOData, ref Rotation UFORotation, ref Translation UFOTranslation)
        {
            Quaternion rotation = UFORotation.Value;
            rotation = UFORotation.Value * Quaternion.AngleAxis(180 * UFOData.rotateSpeed * deltaTime, UFOData.rotationDirection);
            UFORotation.Value = rotation;
            UFOTranslation.Value.z += UFOData.moveSpeed * deltaTime;
            if (UFOTranslation.Value.z > 70f)
            {
                UFOData.moveSpeed = -math.abs(UFOData.moveSpeed);
            }

            if (UFOTranslation.Value.z < -190f)
            {
                UFOData.moveSpeed = +math.abs(UFOData.moveSpeed);
            }

        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float delta = Time.deltaTime;

        UFOControlJob UFOControl = new UFOControlJob
        {
            xMinRange = UFOSpawner.xMinRange,
            xMaxRange = UFOSpawner.xMaxRange,
            yMinRange = UFOSpawner.yMinRange,
            yMaxRange = UFOSpawner.yMaxRange,
            zMinRange = UFOSpawner.zMinRange,
            zMaxRange = UFOSpawner.zMaxRange,
            deltaTime = delta,
        };

        JobHandle UFOControlHandle = UFOControl.Schedule(this, inputDeps);

        return UFOControlHandle;
    }
}
