using UnityEngine;

public class RigidbodyBehavior : SpriteBehavior
{
    public Rigidbody2D rigid_body;

    public static RigidbodyBehavior CreateRigidbodyBehavior(ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
    {
        return InitializeRigidbodyBehavior(new GameObject().AddComponent<RigidbodyBehavior>(), collider_type, sprite_path, x, y);
    }

    public static RigidbodyBehavior InitializeRigidbodyBehavior(RigidbodyBehavior behavior, SpriteBehavior.ColliderType collider_type, string sprite_path, float x = 0, float y = 0)
    {
        InitializeSpriteBehavior(behavior, collider_type, sprite_path, x, y);
        behavior.rigid_body = behavior.gameObject.AddComponent<Rigidbody2D>();
        return behavior;
    }

}

