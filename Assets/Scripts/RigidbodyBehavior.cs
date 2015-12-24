using UnityEngine;

public class RigidbodyBehavior : SpriteBehavior
{
    public Rigidbody2D body;

    public static RigidbodyBehavior InitializeRigidbodyBehavior(RigidbodyBehavior behavior, SpriteBehavior.ColliderType collider_type, string sprite_path, float x, float y)
    {
        InitializeSpriteBehavior(behavior, collider_type, sprite_path, x, y);
        behavior.body = behavior.gameObject.AddComponent<Rigidbody2D>();
        return behavior;
    }

}

