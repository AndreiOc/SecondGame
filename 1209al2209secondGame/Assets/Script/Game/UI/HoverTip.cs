using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour
{

    public EnemyController enemy;
    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(0.05f);
        ShowMessage();
    }

    private void ShowMessage()
    {
        HoverTipManager.OnMouseHover(enemy,Input.mousePosition);
    }

    private void OnMouseOver()
    {
        HoverTipManager.OnMouseHover(enemy,Input.mousePosition);
    }
    private void OnMouseExit()
    {
        HoverTipManager.OnMouseLoseFocus();        
    }
}
