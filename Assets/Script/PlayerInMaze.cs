using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMaze : MonoBehaviour {

    public GameObject alien1;
    public GameObject alien2;
    public GameObject alien3;
    public GameObject alien4;

    public bool disableVertical;

    private Animator animator;

    float speed;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        if (disableVertical) speed = 0f;
        else speed = 2f;

        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

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

            Vector3 pos = transform.position;


            pos.x += 2f * xAxis * Time.deltaTime;

            pos.y += speed * yAxis * Time.deltaTime;




            transform.position = pos;
        }
        
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (pos.x < -6.27f)
            pos.x = -6.27f;
        if (pos.x > 6.27f)
            pos.x = 6.27f;
        if (pos.y > 6.19f)
            pos.y = 6.19f;
        if (pos.y < -6.19f)
            pos.y = -6.19f;
        if (Mathf.Abs(gameObject.transform.position.x + 1.73f) < 0.1f && gameObject.transform.position.y < -6.18f)
        {
            pos.x = -0.5f;
            pos.y = 5.35f;
            MazeController.step++;
            MazeController.playerRoute[MazeController.step] = 4;
            MazeController.whichAlien = 0;
            MazeController.fightedCreeps = false;
        }
        if (Mathf.Abs(gameObject.transform.position.x + 0.48f) < 0.1f && gameObject.transform.position.y > 6.18f)
        {
            pos.x = -1.77f;
            pos.y = -5.37f;
            MazeController.step++;
            MazeController.playerRoute[MazeController.step] = 2;
            MazeController.whichAlien = 0;
            MazeController.fightedCreeps = false;
        }
        if (Mathf.Abs(gameObject.transform.position.y - 1.82f) < 0.1f && gameObject.transform.position.x < -6.26f)
        {
            pos.x = 5.37f;
            pos.y = 2.48f;
            MazeController.step++;
            MazeController.playerRoute[MazeController.step] = 1;
            MazeController.whichAlien = 0;
            MazeController.fightedCreeps = false;
        }
        if (Mathf.Abs(gameObject.transform.position.y - 2.45f) < 0.1f && gameObject.transform.position.x > 6.26f)
        {
            pos.x = -5.24f;
            pos.y = 1.57f;
            MazeController.step++;
            MazeController.playerRoute[MazeController.step] = 3;
            MazeController.whichAlien = 0;
            MazeController.fightedCreeps = false;
        }
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
