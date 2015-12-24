using UnityEngine;
using System.Collections.Generic;

class Behaviors
{
    public static SpriteBehavior BuildSpriteBehavior(SpriteBehavior.ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
    {
        return InitializeSpriteBehavior(new GameObject().AddComponent<SpriteBehavior>(), collider_type, sprite_path, x, y);
    }

    public static RigidbodyBehavior BuildRigidbodyBehavior(SpriteBehavior.ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
    {
        return InitializeRigidbodyBehavior(new GameObject().AddComponent<RigidbodyBehavior>(), collider_type, sprite_path, x, y);
    }

    public static PlayerBehavior BuildPlayerBehavior(float x = 0, float y = 0)
    {
        return InitializePlayerBehavior(new GameObject().AddComponent<PlayerBehavior>(), x, y);
    }

    public static StemBehavior BuildStemBehavior (float x = 0, float y = 0)
    {
        return InitializeStemBehavior(new GameObject().AddComponent<StemBehavior>(), x, y);
    }

    public static CarrotBehavior BuildCarrotBehavior(float x = 0, float y = 0)
    {
        return InitializeCarrotBehavior(new GameObject().AddComponent<CarrotBehavior>(), x, y);
    }


    private static SpriteBehavior InitializeSpriteBehavior(SpriteBehavior sprite_behavior, SpriteBehavior.ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
    {
        var game_object = sprite_behavior.gameObject;

        game_object.transform.position = new Vector3(x, y);
        sprite_behavior.sprite_renderer = game_object.AddComponent<SpriteRenderer>();
        sprite_behavior.sprite_path = sprite_path;
        if (!string.IsNullOrEmpty(sprite_path))
            sprite_behavior.sprite_renderer.sprite = Resources.Load<Sprite>(sprite_path);

        switch (collider_type)
        {
            case SpriteBehavior.ColliderType.Box:
                sprite_behavior.collider2d = game_object.AddComponent<BoxCollider2D>();
                break;
            case SpriteBehavior.ColliderType.Circle:
                sprite_behavior.collider2d = game_object.AddComponent<CircleCollider2D>();
                break;
            case SpriteBehavior.ColliderType.Polygon:
                sprite_behavior.collider2d = game_object.AddComponent<PolygonCollider2D>();
                break;
        }
        sprite_behavior.touching_anything = false;
        return sprite_behavior;
    }

    private static RigidbodyBehavior InitializeRigidbodyBehavior(RigidbodyBehavior behavior, SpriteBehavior.ColliderType collider_type, string sprite_path, float x, float y)
    {
        InitializeSpriteBehavior(behavior, collider_type, sprite_path, x, y);
        behavior.body = behavior.gameObject.AddComponent<Rigidbody2D>();
        return behavior;
    }

    private static PlayerBehavior InitializePlayerBehavior(PlayerBehavior behavior, float x, float y)
    {
        InitializeRigidbodyBehavior(behavior, SpriteBehavior.ColliderType.Polygon, "player", x, y);
        behavior.body.freezeRotation = true;
        return behavior;
    }

    private static StemBehavior InitializeStemBehavior(StemBehavior behavior, float x, float y)
    {
        InitializeSpriteBehavior(behavior, SpriteBehavior.ColliderType.Box, "stem", x, y);
        behavior.touching_player = false;
        return behavior;
    }

    private static CarrotBehavior InitializeCarrotBehavior(CarrotBehavior behavior, float x, float y)
    {
        InitializeRigidbodyBehavior(behavior, SpriteBehavior.ColliderType.Polygon, "carrot", x, y);
        behavior.touching_player = false;
        return behavior;
    }
}