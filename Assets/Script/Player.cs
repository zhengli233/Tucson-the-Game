using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static bool goInDoor;

    public bool disableVertical;
    public AudioSource doorSound;

    private Animator animator;

    float speed;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        if (disableVertical) speed = 0f;
        else speed = 2f;
        goInDoor = false;
        if (ToMap1.fromMap2)
        {
            Vector2 pos;
            pos.x = -1.5f;
            pos.y = -2.987f;
            gameObject.transform.position = pos;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        if (!GameManager.lockPlayer)
        {
            if (Mathf.Abs(xAxis) > 0.1 || Mathf.Abs(yAxis) > 0.1)
            {
                if (Input.GetKey("a") || Input.GetKey("left"))
                {
                    animator.SetBool("left", true);

                }
                else animator.SetBool("left", false);
                if (Input.GetKey("w") || Input.GetKey("up"))
                {
                    animator.SetBool("up", true);

                }
                else animator.SetBool("up", false);
                if (Input.GetKey("s") || Input.GetKey("down"))
                {
                    animator.SetBool("down", true);

                }
                else animator.SetBool("down", false);
                if (Input.GetKey("d") || Input.GetKey("right"))
                {
                    animator.SetBool("right", true);

                }
                else animator.SetBool("right", false);
            }

            


            pos.x += 2f * xAxis * Time.deltaTime;

            pos.y += speed * yAxis * Time.deltaTime;

            transform.position = pos;
        }

        if (transform.position.x < 4.5 && transform.position.x > 4.1)
        {
            if (Mathf.Abs(yAxis) > 0.1)
            {
                if (Input.GetKey("w") || Input.GetKey("up"))
                {
                    GameManager.enterUpDoor = true;
                    
                    if (GameManager.floor < 4)
                    {
                        doorSound.Play();
                        goInDoor = true;
                        pos.y += 1.92f;
                        pos.x -= 8.1f;
                        transform.position = pos;
//                        GameManager.floor++;
                        GameManager.enterUpDoor = false;
                    }
                }
                
            }
            
        }

        if (transform.position.x < -4.1 && transform.position.x > -4.5)
        {
            if (Mathf.Abs(yAxis) > 0.1)
            {
                if (Input.GetKey("w") || Input.GetKey("up"))
                {
                    GameManager.enterUpDoor = true;

                    if (GameManager.floor > 1)
                    {
                        if (GameManager.floor == 4 && GameManager.askedProf) 
                            GoDownStairs();
                        if (GameManager.floor == 3 && GameManager.michaelRequestDone)
                            GoDownStairs();
                        if (GameManager.floor == 2 && GameManager.neilRequestDone)
                            GoDownStairs();
                    }
                }

            }

        }
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        if (pos.x < -4.63f)
            pos.x = -4.63f;
        if (pos.x > 4.63f)
            pos.x = 4.63f;
        transform.position = pos;
    }

    void HideChildren()
    {
        Renderer[] lChildRenderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled = false;
        }
    }
    void ShowChildren()
    {
        Renderer[] lChildRenderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled = true;
        }
    }

    void GoDownStairs()
    {
        Vector3 pos = transform.position;
        doorSound.Play();
        goInDoor = true;
        pos.y -= 1.92f;
        pos.x += 8.1f;
        transform.position = pos;
//        GameManager.floor--;
        GameManager.enterUpDoor = false;
    }
}
