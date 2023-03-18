using System;
using Tweens;

public class Blackout : MonoBehaviour
{
    SpriteRenderer blackSquare;

    private T_SpriteColorChange colorChange;

    public void GoOpaque()
    {
        colorChange?.End();
        colorChange = new T_SpriteColorChange(blackSquare, .5f, Color.black);
    }

    public void GoClear()
    {
        colorChange?.End();
        colorChange = new T_SpriteColorChange(blackSquare, .5f, Color.clear);
    }
}
