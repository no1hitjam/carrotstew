using UnityEngine;

public class SpriteBehavior : MonoBehaviour
{
    public enum ColliderType
    {
        Box,
        Circle,
        Polygon
    }

    public bool touching_anything;
    public string sprite_path;
    public SpriteRenderer sprite_renderer;
    public Collider2D collider2d;

    public static SpriteBehavior InitializeSpriteBehavior(SpriteBehavior sprite_behavior, SpriteBehavior.ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
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

    void OnCollisionEnter2D()
    {
        this.touching_anything = true;
    }

    void OnCollisionExit2D()
    {
        this.touching_anything = false;
    }

    void OnCollisionStay2D()
    {
        this.touching_anything = true;
    }

}

