using UnityEngine;

public class RigidbodyObject
{
    public GameObject game_object;
    protected SpriteRenderer renderer;
    public Rigidbody2D body;
    public PolygonCollider2D collider;
    protected RigidbodyBehavior behavior;

    public RigidbodyObject(string sprite_path="", int x=0, int y=0)
    {
        this.game_object = new GameObject();
        this.game_object.transform.position = new Vector3(x, y);

        this.renderer = this.game_object.AddComponent<SpriteRenderer>();
        if (!string.IsNullOrEmpty(sprite_path))
            this.renderer.sprite = Resources.Load<Sprite>(sprite_path);

        this.body = this.game_object.AddComponent<Rigidbody2D>();
        this.collider = this.game_object.AddComponent<PolygonCollider2D>();
        this.behavior = this.game_object.AddComponent<RigidbodyBehavior>();
    }

    public bool Touching()
    {
        return this.behavior.touching;
    }

}

