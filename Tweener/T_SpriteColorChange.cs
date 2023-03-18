using UnityEngine;

namespace Tweens
{
    public class T_SpriteColorChange : Tween
    {
        private SpriteRenderer sr;
        private Color startColor;
        private Color endColor;
        private float durationInSec;
        private float elapsedTimeInSec;


        public T_SpriteColorChange(SpriteRenderer sr, float durationInSec, Color endColor) : base()
        {
            this.sr = sr;
            this.durationInSec = durationInSec;
            elapsedTimeInSec = 0;
            startColor = sr.color;
            this.endColor = endColor;
        }

        public override void LogicUpdate()
        {
            float t = elapsedTimeInSec / durationInSec;
            sr.color = Color.Lerp(startColor, endColor, t);
            elapsedTimeInSec += Time.deltaTime;
            if (elapsedTimeInSec > durationInSec)
            {
                sr.color = endColor;
                End();
            }
        }

        public override void End()
        {
            base.End();
        }
    }
}
