﻿using UnityEngine;
using System.Collections.Generic;

public class Main : MonoBehaviour {

    private UIButtonInput left_button;
    private UIButtonInput right_button;
    private UIButtonInput jump_button;
    private UIButtonInput action_button;

    private PlayerBehavior player;
    private RigidbodyBehavior carrying_carrot;
    private List<RigidbodyBehavior> carrots;
    private List<StemBehavior> stems;

	// Use this for initialization
	void Start () {
        this.left_button = GameObject.Find("Left Button").GetComponent<UIButtonInput>();
        this.right_button = GameObject.Find("Right Button").GetComponent<UIButtonInput>();
        this.jump_button = GameObject.Find("Jump Button").GetComponent<UIButtonInput>();
        this.action_button = GameObject.Find("Action Button").GetComponent<UIButtonInput>();

        this.player = Behaviors.BuildPlayerBehavior(1, 1);
        this.carrying_carrot = null;
        this.carrots = new List<RigidbodyBehavior>();
        this.stems = new List<StemBehavior>();

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
            this.carrying_carrot.gameObject.transform.position = this.player.gameObject.transform.position + new Vector3(0, 1);
    }

    public void Action()
    {
        var touching_stem = this.FindStemTouchingPlayer();

        if (this.carrying_carrot == null && touching_stem != null)
        {
            this.carrying_carrot = Behaviors.BuildRigidbodyBehavior(SpriteBehavior.ColliderType.Polygon, "carrot");
            this.carrying_carrot.collider2d.enabled = false;
            stems.Remove(touching_stem);
            Destroy(touching_stem.gameObject);
        }
        else if (this.carrying_carrot != null)
        {
            this.carrying_carrot.body.velocity = this.player.body.velocity + new Vector2(PlayerBehavior.horiz_throw * this.player.facing, PlayerBehavior.vert_throw);
            this.carrying_carrot.collider2d.enabled = true;
            carrots.Add(this.carrying_carrot);
            this.carrying_carrot = null;
        }
    }

    private StemBehavior FindStemTouchingPlayer()
    {
        foreach (var stem in this.stems)
        {
            if (stem.touching_player)
            {
                return stem;
            }
        }
        return null;
    }

    private void AddStem()
    {
        var stem = Behaviors.BuildStemBehavior(0, -5);//Behaviors.BuildSpriteBehavior(SpriteBehavior.ColliderType.Box, "stem", 0, -5);
        stem.collider2d.isTrigger = true;
        this.stems.Add(stem);
    }
}
