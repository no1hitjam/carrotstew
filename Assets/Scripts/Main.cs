using UnityEngine;
using System.Collections.Generic;

public class Main : MonoBehaviour {

    private UIButtonInput left_button;
    private UIButtonInput right_button;
    private UIButtonInput jump_button;
    private UIButtonInput action_button;

    private Player player;
    private RigidbodyObject carrying_carrot;
    private List<RigidbodyObject> carrots;
    private List<SpriteObject> stems;

	// Use this for initialization
	void Start () {
        this.left_button = GameObject.Find("Left Button").GetComponent<UIButtonInput>();
        this.right_button = GameObject.Find("Right Button").GetComponent<UIButtonInput>();
        this.jump_button = GameObject.Find("Jump Button").GetComponent<UIButtonInput>();
        this.action_button = GameObject.Find("Action Button").GetComponent<UIButtonInput>();

        this.player = new Player(1, 1);
        this.carrying_carrot = null;
        this.carrots = new List<RigidbodyObject>();
        this.stems = new List<SpriteObject>();

        this.AddStem();
    }
	
	// Update is called once per frame
	void Update () {
        // check inputs
        if (this.left_button.pressed || Input.GetButton("Left"))
            this.player.MoveLeft();
        if (this.right_button.pressed || Input.GetButton("Right"))
            this.player.MoveRight();
        if (this.jump_button.getSinglePress() || Input.GetButtonDown("Jump"))
            this.player.Jump();
        if (this.action_button.getSinglePress() || Input.GetButtonDown("Action"))
            this.Action();

        if (this.carrying_carrot != null)
            this.carrying_carrot.game_object.transform.position = this.player.game_object.transform.position + new Vector3(0, 1);
    }

    public void Action()
    {
        if (this.carrying_carrot == null)
        {
            this.carrying_carrot = new RigidbodyObject(SpriteObject.ColliderType.Polygon, "carrot");
            this.carrying_carrot.collider.enabled = false;
        }
        else if (this.carrying_carrot != null)
        {
            this.carrying_carrot.body.velocity = this.player.body.velocity + new Vector2(Player.horiz_throw * this.player.facing, Player.vert_throw);
            this.carrying_carrot.collider.enabled = true;
            carrots.Add(this.carrying_carrot);
            this.carrying_carrot = null;
        }
    }

    private SpriteObject StemTouchingPlayer()
    {

    }

    private void AddStem()
    {
        var stem = new SpriteObject(SpriteObject.ColliderType.Box, "stem", 0, -5);
        stem.collider.isTrigger = true;
    }
}
