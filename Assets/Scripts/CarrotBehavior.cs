using UnityEngine;

class CarrotBehavior : RigidbodyBehavior
{
    public bool touching_player;

    public static CarrotBehavior InitializeCarrotBehavior(CarrotBehavior behavior, float x, float y)
    {
        InitializeRigidbodyBehavior(behavior, SpriteBehavior.ColliderType.Polygon, "carrot", x, y);
        behavior.touching_player = false;
        return behavior;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehavior>())
        {
            touching_player = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehavior>())
        {
            touching_player = false;
        }
    }
}
