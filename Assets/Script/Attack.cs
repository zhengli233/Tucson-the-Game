using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {
    
    void OnEnable () {
        ShowAttack();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void ShowAttack()
    {        
        gameObject.SetActive(true);
        Invoke("HideAttack", 1f);
    }

    void HideAttack()
    {
        gameObject.SetActive(false);
        
        BattleController.enermyHealth -= 40;
        
        BattleController.turn = false;
    }
}
