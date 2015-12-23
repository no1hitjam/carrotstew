using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    private const float speed = .05f;
    private const float vert_throw = 5;
    private const float horiz_throw = 2;
    private const float jump = 7;

    private Rigidbody2D rigid_body;
    private BoxCollider2D box_collider;

    private bool grounded;
    private int facing;
    private Carrot carrying_carrot;
    private List<Carrot> carrots;

    // Use this for initialization
    void Start () {
        this.rigid_body = this.GetComponent<Rigidbody2D>();
        this.box_collider = this.GetComponent<BoxCollider2D>();
        this.grounded = true;
        this.carrying_carrot = null;
        this.carrots = new List<Carrot>();
        this.facing = 1;
	}
	
	// Update is called once per frame
	void Update () {
        // left and right movement
        if (Input.GetButton("Left"))
            this.MoveLeft();
        if (Input.GetButton("Right"))
            this.MoveRight();

        //this.transform.position += new Vector3(this.x_move, 0);

        // jump
        if (Input.GetButtonDown("Jump"))
            this.Jump();
        // pull up/throw carrot
        if (Input.GetButtonDown("Action"))
            this.Action();

        if (this.carrying_carrot != null)
            this.carrying_carrot.game_object.transform.position = this.transform.position + new Vector3(0, 1);
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (collisionInfo.contacts.Length > 0)
        {
            this.grounded = true;
        }
    }


    public void MoveLeft()
    {
        this.transform.position += new Vector3(-speed, 0);
        this.facing = -1;
    }

    public void MoveRight()
    {
        this.transform.position += new Vector3(speed, 0);
        this.facing = 1;
    }

    public void Jump()
    {
        if (this.grounded)
        {
            this.rigid_body.velocity = new Vector2(0, jump);
            this.grounded = false;
        }
    }

    public void Action()
    {
        if (this.grounded && this.carrying_carrot == null)
        {
            this.carrying_carrot = new Carrot();
            this.carrying_carrot.collider.enabled = false;
        }
        else if (this.carrying_carrot != null)
        {
            this.carrying_carrot.body.velocity = this.rigid_body.velocity + new Vector2(horiz_throw * this.facing, vert_throw);
            this.carrying_carrot.collider.enabled = true;
            carrots.Add(this.carrying_carrot);
            this.carrying_carrot = null;
        }
    }

}
