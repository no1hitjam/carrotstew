using UnityEngine;

class StemBehavior : SpriteBehavior
{
    public bool touching_player;

    public static StemBehavior CreateStemBehavior(float x = 0, float y = 0)
    {
        return InitializeStemBehavior(new GameObject().AddComponent<StemBehavior>(), x, y);
    }

    protected static StemBehavior InitializeStemBehavior(StemBehavior behavior, float x, float y)
    {
        InitializeSpriteBehavior(behavior, SpriteBehavior.ColliderType.Box, "stem", x, y);
        behavior.touching_player = false;
        behavior.gameObject.transform.localScale = new Vector3(CarrotBehavior.scale, CarrotBehavior.scale);
        return behavior;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>())
        {
            touching_player = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>())
        {
            touching_player = false;
        }
    }
}
