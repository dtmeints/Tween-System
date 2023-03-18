using UnityEngine;
using System;

namespace Tweens
{
    public abstract class Tween
    {

        public static event Action<Tween> OnTweenCreated;
        public static event Action<Tween> OnTweenDone;

        public Tween() => OnTweenCreated?.Invoke(this);

        public virtual void LogicUpdate()
        {

        }

        public virtual void End() => OnTweenDone?.Invoke(this);
    }
}