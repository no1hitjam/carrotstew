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
    public Sprite[] sprites;

    public static SpriteBehavior CreateSpriteBehavior(ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
    {
        return InitializeSpriteBehavior(new GameObject().AddComponent<SpriteBehavior>(), collider_type, sprite_path, x, y);
    }

    protected static SpriteBehavior InitializeSpriteBehavior(SpriteBehavior behavior, ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
    {
        var game_object = behavior.gameObject;

        game_object.transform.position = new Vector3(x, y);
        behavior.sprite_renderer = game_object.AddComponent<SpriteRenderer>();
        behavior.sprite_path = sprite_path;
        if (!string.IsNullOrEmpty(sprite_path))
        {
            behavior.sprites = Resources.LoadAll<Sprite>(sprite_path);
            behavior.sprite_renderer.sprite = behavior.sprites[0];
        }

        switch (collider_type)
        {
            case SpriteBehavior.ColliderType.Box:
                behavior.collider2d = game_object.AddComponent<BoxCollider2D>();
                break;
            case SpriteBehavior.ColliderType.Circle:
                behavior.collider2d = game_object.AddComponent<CircleCollider2D>();
                break;
            case SpriteBehavior.ColliderType.Polygon:
                behavior.collider2d = game_object.AddComponent<PolygonCollider2D>();
                break;
        }
        behavior.touching_anything = false;
        return behavior;
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

