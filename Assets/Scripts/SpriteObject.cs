using UnityEngine;

public class SpriteObject
{
    public enum ColliderType
    {
        Box,
        Circle,
        Polygon
    }
    public GameObject game_object;
    protected SpriteRenderer renderer;
    public Collider2D collider;
    protected ColliderBehavior behavior;

    public SpriteObject(ColliderType collider_type, string sprite_path = "", int x = 0, int y = 0)
    {
        this.game_object = new GameObject();
        this.game_object.transform.position = new Vector3(x, y);

        this.renderer = this.game_object.AddComponent<SpriteRenderer>();
        if (!string.IsNullOrEmpty(sprite_path))
            this.renderer.sprite = Resources.Load<Sprite>(sprite_path);

        switch(collider_type)
        {
            case ColliderType.Box:
                this.collider = this.game_object.AddComponent<BoxCollider2D>();
                break;
            case ColliderType.Circle:
                this.collider = this.game_object.AddComponent<CircleCollider2D>();
                break;
            case ColliderType.Polygon:
                this.collider = this.game_object.AddComponent<PolygonCollider2D>();
                break;
        }

        this.behavior = this.game_object.AddComponent<ColliderBehavior>();
    }

    public bool Touching()
    {
        return this.behavior.touching;
    }

}

