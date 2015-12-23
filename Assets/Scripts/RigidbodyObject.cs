using UnityEngine;

public class RigidbodyObject : SpriteObject
{
    public Rigidbody2D body;

    public RigidbodyObject(ColliderType collider_type, string sprite_path ="", int x=0, int y=0) : base (collider_type, sprite_path, x, y)
    {
        this.body = this.game_object.AddComponent<Rigidbody2D>();
    }

}

