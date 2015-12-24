using UnityEngine;

class CarrotBehavior : RigidbodyBehavior
{
    public bool touching_player;

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
