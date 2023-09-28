using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetection : MonoBehaviour
{
    public bool isClicked = false;

    public void OnPointerClick()
    {
        // ƒNƒŠƒbƒN‚³‚ê‚½‚çisClicked‚ğtrue‚Éİ’è
        isClicked = true;
        
    }

}
