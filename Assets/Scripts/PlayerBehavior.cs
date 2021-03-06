﻿using UnityEngine;
using System.Collections.Generic;

class PlayerBehavior : RigidbodyBehavior
{
    public int facing;

    public const float speed = .05f;
    public const float vert_throw = 6;
    public const float horiz_throw = 3;
    public const float jump = 7;
    public const float scale = .2f;

    public static PlayerBehavior CreatePlayerBehavior()
    {
        return InitializePlayerBehavior(new GameObject().AddComponent<PlayerBehavior>());
    }

    protected static PlayerBehavior InitializePlayerBehavior(PlayerBehavior behavior)
    {
        InitializeRigidbodyBehavior(behavior, SpriteBehavior.ColliderType.Polygon, "player");
        behavior.rigid_body.freezeRotation = true;
        behavior.ResetPosition();
        behavior.gameObject.transform.localScale = new Vector3(scale, scale);
        return behavior;
    }

    public void ResetPosition()
    {
        this.transform.position = new Vector3(1, 1);
        this.rigid_body.velocity = new Vector2(0, 0);
    }

    void Update()
    {
        if (this.transform.position.y < -30)
        {
            this.ResetPosition();
        }
    }

    public void MoveLeft()
    {
        this.gameObject.transform.position += new Vector3(-speed, 0);
        this.facing = -1;
        this.gameObject.transform.localScale = new Vector3(scale, scale, 1);
    }

    public void MoveRight()
    {
        this.gameObject.transform.position += new Vector3(speed, 0);
        this.facing = 1;
        this.gameObject.transform.localScale = new Vector3(-scale, scale, 1);
    }

    public void Jump()
    {
        if (this.touching_anything)
        {
            this.rigid_body.velocity = new Vector2(0, jump);
            this.sprite_renderer.sprite = this.sprites[1];
        }
    }

    void OnCollisionEnter2D()
    {
        this.touching_anything = true;
        this.sprite_renderer.sprite = this.sprites[0];
    }

}