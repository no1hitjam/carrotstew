using UnityEngine;

class Carrot
{
    public GameObject game_object;
    public SpriteRenderer renderer;
    public Rigidbody2D body;
    public PolygonCollider2D collider;

    public Carrot()
    {
        this.game_object = new GameObject();

        this.renderer = this.game_object.AddComponent<SpriteRenderer>();
        this.renderer.sprite = Resources.Load<Sprite>("carrot");
            
        this.body = this.game_object.AddComponent<Rigidbody2D>();
        this.collider = this.game_object.AddComponent<PolygonCollider2D>();
    }

}

