using UnityEngine;

public class ColliderBehavior : MonoBehaviour {

    public bool touching;

    // Use this for initialization
    void Start () {
        this.touching = false;
	}

    void OnCollisionEnter2D()
    {
        this.touching = true;
    }

    void OnCollisionExit2D()
    {
        this.touching = false;
    }

    void OnCollisionStay2D()
    {
        this.touching = true;
    }

}
