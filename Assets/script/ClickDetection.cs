using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetection : MonoBehaviour
{
    public bool isClicked = false;

    public void OnPointerClick()
    {
        // �N���b�N���ꂽ��isClicked��true�ɐݒ�
        isClicked = true;
        
    }

}
