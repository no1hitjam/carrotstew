using UnityEngine;
using System.Collections.Generic;

class Behaviors
{
    public static SpriteBehavior BuildSpriteBehavior(SpriteBehavior.ColliderType collider_type, string sprite_path = "", int x = 0, int y = 0)
    {
        return InitializeSpriteBehavior(new GameObject().AddComponent<SpriteBehavior>(), collider_type, sprite_path, x, y);
    }

    public static RigidbodyBehavior BuildRigidbodyBehavior(SpriteBehavior.ColliderType collider_type, string sprite_path = "", int x = 0, int y = 0)
    {
        return InitializeRigidbodyBehavior(new GameObject().AddComponent<RigidbodyBehavior>(), collider_type, sprite_path, x, y);
    }

    public static PlayerBehavior BuildPlayerBehavior(int x = 0, int y = 0)
    {
        return InitializePlayerBehavior(new GameObject().AddComponent<PlayerBehavior>(), x, y);
    }

    public static StemBehavior BuildStemBehavior (int x = 0, int y = 0)
    {
        return InitializeStemBehavior(new GameObject().AddComponent<StemBehavior>(), x, y);
    }


    private static SpriteBehavior InitializeSpriteBehavior(SpriteBehavior sprite_behavior, SpriteBehavior.ColliderType collider_type, string sprite_path = "", int x = 0, int y = 0)
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

    private static RigidbodyBehavior InitializeRigidbodyBehavior(RigidbodyBehavior rigidbody_behavior, SpriteBehavior.ColliderType collider_type, string sprite_path, int x, int y)
    {
        InitializeSpriteBehavior(rigidbody_behavior, collider_type, sprite_path, x, y);
        rigidbody_behavior.body = rigidbody_behavior.gameObject.AddComponent<Rigidbody2D>();
        return rigidbody_behavior;
    }

    private static PlayerBehavior InitializePlayerBehavior(PlayerBehavior player_behavior, int x, int y)
    {
        InitializeRigidbodyBehavior(player_behavior, SpriteBehavior.ColliderType.Polygon, "player", x, y);
        player_behavior.touching_stems = new HashSet<GameObject>();
        player_behavior.body.freezeRotation = true;
        return player_behavior;
    }

    private static StemBehavior InitializeStemBehavior(StemBehavior stem_behavior, int x, int y)
    {
        InitializeSpriteBehavior(stem_behavior, SpriteBehavior.ColliderType.Box, "stem", x, y);
        stem_behavior.touching_player = false;
        return stem_behavior;
    }
}