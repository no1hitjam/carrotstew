using UnityEngine;
using System.Collections.Generic;

public class RigidbodyBehavior : MonoBehaviour {

    public bool touching;

    // Use this for initialization
    void Start () {
        this.touching = false;
	}

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (collisionInfo.contacts.Length > 0)
            this.touching = true;
        else
            this.touching = false;
    }

}
