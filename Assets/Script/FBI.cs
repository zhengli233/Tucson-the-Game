using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBI : MonoBehaviour {
    public GameObject player;
    public GameObject labDoor;

    private Animator animator;

    bool left = false;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;


        if (Mathf.Abs(player.transform.position.x - labDoor.transform.position.x) < 0.3 && Mathf.Abs(player.transform.position.y - labDoor.transform.position.y) < 0.1)
        {
            GameManager.metFBIFloor3 = true;
            GoLeft();
        }


        if (left)
        {
            pos.x -= 2f * Time.deltaTime;
            transform.position = pos;
        }
     
    }

    public void GoLeft()
    {
        animator.SetBool("left", true);
        left = true;
        Invoke("Stop", 2f);
    }

    public void Stop()
    {
        animator.SetBool("left", false);
        left = false;
        gameObject.SetActive(false);
    }
}
