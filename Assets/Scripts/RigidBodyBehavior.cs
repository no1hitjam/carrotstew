using UnityEngine;

public class RigidbodyBehavior : MonoBehaviour {

    public bool touching;

    // Use this for initialization
    void Start () {
        this.touching = false;
	}

    void OnCollisionEnter2D()
    {
        this.touching = true;
    }

    void OnCollisionExit2D(Collision2D collision_info)
    {
        this.touching = false;
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        this.touching = true;
    }

}
