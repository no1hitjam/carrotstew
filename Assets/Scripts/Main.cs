using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    private UIButtonInput left_button;
    private UIButtonInput right_button;
    private UIButtonInput jump_button;
    private UIButtonInput action_button;

    private Player player;

	// Use this for initialization
	void Start () {
        var canvas = GameObject.Find("Canvas");
        this.left_button = GameObject.Find("Left Button").GetComponent<UIButtonInput>();
        this.right_button = GameObject.Find("Right Button").GetComponent<UIButtonInput>();
        this.jump_button = GameObject.Find("Jump Button").GetComponent<UIButtonInput>();
        this.action_button = GameObject.Find("Action Button").GetComponent<UIButtonInput>();

        this.player = GameObject.Find("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.left_button.pressed)
            this.player.MoveLeft();
        if (this.right_button.pressed)
            this.player.MoveRight();
        if (this.jump_button.getSinglePress())
            this.player.Jump();
        if (this.action_button.getSinglePress())
            this.player.Action();
	}
}
