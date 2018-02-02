using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInDowntown2 : MonoBehaviour {

    public GameObject controller;
    public GameObject playerPanel;
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
        controller.GetComponent<FightInDowntown>().Attack();
    }
}
