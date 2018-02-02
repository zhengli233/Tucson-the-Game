using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBIDu : MonoBehaviour {
    public GameObject player;
    

    private Animator animator;

    bool left = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;


        if (Mathf.Abs(player.transform.position.x - 2.82f) < 0.3 && Mathf.Abs(player.transform.position.y + 2.979f) < 0.1)
        {
            GameManager.metFBIFloor1 = true;
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
