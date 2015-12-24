using UnityEngine;
using System.Collections.Generic;

class PlayerBehavior : RigidbodyBehavior
{
    public int facing;

    public const float speed = .05f;
    public const float vert_throw = 6;
    public const float horiz_throw = 3;
    public const float jump = 7;

    public void MoveLeft()
    {
        this.gameObject.transform.position += new Vector3(-speed, 0);
        this.facing = -1;
    }

    public void MoveRight()
    {
        this.gameObject.transform.position += new Vector3(speed, 0);
        this.facing = 1;
    }

    public void Jump()
    {
        if (this.touching_anything)
        {
            this.body.velocity = new Vector2(0, jump);
        }
    }

}