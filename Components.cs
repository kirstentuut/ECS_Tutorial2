using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct PlayerInput : IComponentData
{
    public float Horizontal;
}

public struct Floor : IComponentData {}
public struct Fly : IComponentData {}
public struct Jump : IComponentData{}
