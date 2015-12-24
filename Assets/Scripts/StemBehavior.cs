using UnityEngine;

class StemBehavior : SpriteBehavior
{
    public bool touching_player;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>())
        {
            touching_player = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>())
        {
            touching_player = false;
        }
    }
}
