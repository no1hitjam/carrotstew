using UnityEngine;
using System.Collections.Generic;

class PlayerBehavior : RigidbodyBehavior
{
    public int facing;

    public const float speed = .05f;
    public const float vert_throw = 10;
    public const float horiz_throw = 4;
    public const float jump = 7;

    public HashSet<GameObject> touching_stems;

    public PlayerBehavior()
    {
        this.touching_stems = new HashSet<GameObject>();
    }

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

    public GameObject PopStem()
    {
        GameObject pop_stem = null;
        foreach (var stem in this.touching_stems)
        {
            pop_stem = stem;
            break;
        }
        this.touching_stems.Remove(pop_stem);
        return pop_stem;
    }

    void OnCollisionEnter2D(Collision2D collision_info)
    {
        if (collision_info.gameObject.GetComponent<SpriteBehavior>() && collision_info.gameObject.GetComponent<SpriteBehavior>().sprite_path == "stem")
        {
            touching_stems.Add(collision_info.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision_info)
    {
        touching_stems.Remove(collision_info.gameObject);
    }

}