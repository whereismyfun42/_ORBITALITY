using System;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

[Serializable]
public struct UFORotationData : IComponentData
{
    public float rotateSpeed;
    public float3 rotationDirection;
    public float moveSpeed;
}

public class UFORotationComponent : ComponentDataProxy<UFORotationData> { }
