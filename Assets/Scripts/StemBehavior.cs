using UnityEngine;

class StemBehavior : SpriteBehavior
{
    public bool touching_player;

    public static StemBehavior InitializeStemBehavior(StemBehavior behavior, float x, float y)
    {
        InitializeSpriteBehavior(behavior, SpriteBehavior.ColliderType.Box, "stem", x, y);
        behavior.touching_player = false;
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
