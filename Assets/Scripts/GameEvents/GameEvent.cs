using System;
using UnityEngine;

public static class GameEvent
{
    // 定义一个事件，带有开火者和武器类型的信息
    public static Action<string, string, Transform> OnFire;
}