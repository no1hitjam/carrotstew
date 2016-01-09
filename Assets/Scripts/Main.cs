using UnityEngine;
using System.Collections.Generic;

public class Main : MonoBehaviour {

    private UIButtonInput left_button;
    private UIButtonInput right_button;
    private UIButtonInput jump_button;
    private UIButtonInput action_button;

    private PlayerBehavior player;
    private CarrotBehavior carrying_carrot;
    private List<CarrotBehavior> carrots;
    private List<StemBehavior> stems;

    private GameObject main_camera;

	// Use this for initialization
	void Start () {
        this.main_camera = GameObject.Find("Main Camera");

        // mobile
        /*this.left_button = GameObject.Find("Left Button").GetComponent<UIButtonInput>();
        this.right_button = GameObject.Find("Right Button").GetComponent<UIButtonInput>();
        this.jump_button = GameObject.Find("Jump Button").GetComponent<UIButtonInput>();
        this.action_button = GameObject.Find("Action Button").GetComponent<UIButtonInput>();*/
        // end mobile

        // pc
        this.left_button = new UIButtonInput();
        this.right_button = new UIButtonInput();
        this.jump_button = new UIButtonInput();
        this.action_button = new UIButtonInput();
        // end pc

        this.player = PlayerBehavior.CreatePlayerBehavior();
        this.carrying_carrot = null;
        this.carrots = new List<CarrotBehavior>();
        this.stems = new List<StemBehavior>();

        this.AddStem();
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
            this.carrying_carrot.gameObject.transform.position = this.player.gameObject.transform.position + new Vector3(0, 1f);

        this.main_camera.transform.position = new Vector3(this.player.gameObject.transform.position.x, 0, -10);
    }

    public void Action()
    {
        var touching_stem = this.FindStemTouchingPlayer();
        var touching_carrot = this.FindCarrotsTouchingPlayer();

        
        if (this.carrying_carrot == null)
        {
            // pick up
            if (touching_carrot != null)
            {
                // existing carrot
                this.carrying_carrot = touching_carrot;
                this.carrying_carrot.collider2d.enabled = false;
                this.carrots.Remove(carrying_carrot);
            }
            else if (touching_stem != null)
            {
                // stem
                this.carrying_carrot = CarrotBehavior.CreateCarrotBehavior();
                this.carrying_carrot.collider2d.enabled = false;
                this.stems.Remove(touching_stem);
                Destroy(touching_stem.gameObject);
                this.AddStem();
            }
        }
        else if (this.carrying_carrot != null)
        {
            // throw carrot
            this.carrying_carrot.gameObject.transform.position += new Vector3(0, 1);
            this.carrying_carrot.rigid_body.velocity = this.player.rigid_body.velocity + new Vector2(PlayerBehavior.horiz_throw * this.player.facing, PlayerBehavior.vert_throw);
            this.carrying_carrot.collider2d.enabled = true;
            this.carrying_carrot.touching_player = false;
            this.player.touching_anything = false;
            carrots.Add(this.carrying_carrot);
            this.carrying_carrot = null;
        }
    }

    private StemBehavior FindStemTouchingPlayer()
    {
        foreach (var stem in this.stems)
            if (stem.touching_player)
                return stem;
        return null;
    }

    private CarrotBehavior FindCarrotsTouchingPlayer()
    {
        foreach (var carrot in this.carrots)
            if (carrot.touching_player)
                return carrot;
        return null;
    }

    private void AddStem()
    {
        var stem = StemBehavior.CreateStemBehavior(Random.Range(-6, 6), -5);
        stem.collider2d.isTrigger = true;
        this.stems.Add(stem);
    }
}
