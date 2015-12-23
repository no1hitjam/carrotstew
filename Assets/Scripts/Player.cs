using UnityEngine;

class Player : RigidbodyObject
{
    public int facing;

    public const float speed = .05f;
    public const float vert_throw = 10;
    public const float horiz_throw = 4;
    public const float jump = 7;
    

    public Player (int x, int y) : base(SpriteObject.ColliderType.Polygon, "player", x, y)
    {
        this.body.freezeRotation = true;
    }

    public void MoveLeft()
    {
        this.game_object.transform.position += new Vector3(-speed, 0);
        this.facing = -1;
    }

    public void MoveRight()
    {
        this.game_object.transform.position += new Vector3(speed, 0);
        this.facing = 1;
    }

    public void Jump()
    {
        if (this.Touching())
        {
            this.body.velocity = new Vector2(0, jump);
        }
    }

}