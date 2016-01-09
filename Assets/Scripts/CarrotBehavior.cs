using UnityEngine;

class CarrotBehavior : RigidbodyBehavior
{
    public static float scale = .25f;

    public bool touching_player;

    public static CarrotBehavior CreateCarrotBehavior(float x = 0, float y = 0)
    {
        return InitializeCarrotBehavior(new GameObject().AddComponent<CarrotBehavior>(), x, y);
    }

    protected static CarrotBehavior InitializeCarrotBehavior(CarrotBehavior behavior, float x, float y)
    {
        InitializeRigidbodyBehavior(behavior, ColliderType.Polygon, "carrot", x, y);
        behavior.touching_player = false;
        behavior.gameObject.transform.localScale = new Vector3(scale, scale);
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
