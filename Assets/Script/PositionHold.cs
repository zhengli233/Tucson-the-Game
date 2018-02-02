using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHold : MonoBehaviour {

    public static PositionHold hold;

    public GameObject player;
    public Vector2 pos;

    private void Awake()
    {
        if (hold == null)
        {
            DontDestroyOnLoad(gameObject);
            hold = this;
        }
        else if (hold != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        pos = player.transform.position;
    }
}
