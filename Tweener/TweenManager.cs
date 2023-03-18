using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tweens
{
    public class TweenManager : MonoBehaviour
    {
        private List<Tween> tweens = new();

        private event Action Tick;

        private void OnEnable()
        {
            Tween.OnTweenCreated += AddToList;
            Tween.OnTweenDone += RemoveFromList;
        }

        private void OnDisable()
        {
            Tween.OnTweenCreated -= AddToList;
            Tween.OnTweenDone -= RemoveFromList;
        }

        private void AddToList(Tween tween)
        {
            tweens.Add(tween);
            Tick += tween.LogicUpdate;
        }

        private void RemoveFromList(Tween tween)
        {
            if (tweens.Contains(tween))
            {
                tweens.Remove(tween);
                Tick -= tween.LogicUpdate;
            }
        }

        private void Update()
        {
            Tick?.Invoke();
        }

        private void OnDestroy()
        {
            foreach (var tween in tweens)
            {
                Tick -= tween.LogicUpdate;
            }
        }
    }
}
