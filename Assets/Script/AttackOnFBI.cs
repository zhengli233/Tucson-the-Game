using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnFBI : MonoBehaviour {

    public GameObject controller;

    // Use this for initialization
    void OnEnable()
    {
        ShowAttack();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowAttack()
    {
        gameObject.SetActive(true);

        Invoke("HideAttack", 1f);
    }

    void HideAttack()
    {
        gameObject.SetActive(false);
        controller.GetComponent<FightInMaze>().EnemyAttack();
    }
}
