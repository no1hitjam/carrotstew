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

