using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreditUI : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CreditsEnd();
        }
    }
    public void CreditsEnd()
    {
        transform.parent.gameObject.SetActive(false);
        menuUI.SetActive(true);
    }

}
