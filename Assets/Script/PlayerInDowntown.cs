using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInDowntown : MonoBehaviour
{
    public bool disableVertical;

    private Animator animator;

    float speed;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        if (disableVertical) speed = 0f;
        else speed = 2f;

/*        if (ToMap1.fromMap2)
        {
            Vector2 pos;
            pos.x = -1.5f;
            pos.y = -2.987f;
            gameObject.transform.position = pos;

        }*/
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
        
        if (pos.x < -8.94f)
            pos.x = -8.94f;
        if (pos.x > 9.26f)
            pos.x = 9.26f;
        if (pos.y > 15)
            pos.y = 15;
        if (pos.y < -15)
            pos.y = -15;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    
}

