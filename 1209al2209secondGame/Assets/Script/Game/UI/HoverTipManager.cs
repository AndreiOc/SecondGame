using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class HoverTipManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI healtText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI astutenessText;
    public TextMeshProUGUI luckText;
        
    public RectTransform tipWindow;

    public static Action<EnemyController,Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    private void ShowTip(EnemyController enemy, Vector2 mousePos)
    {
        healtText.text = enemy.Health.ToString();
        strengthText.text = enemy.Strength.ToString();
        defenseText.text = enemy.Defense.ToString();
        speedText.text = enemy.Speed.ToString();
        astutenessText.text = enemy.Astuteness.ToString();
        luckText.text = enemy.Luck.ToString();
        //tipWindow.sizeDelta = new Vector2(tipText.preferredHeight > 200 ? 200 : tipText.preferredWidth,tipText.preferredHeight); 
        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2 (mousePos.x + tipWindow.sizeDelta.x /2 ,mousePos.y);                
    }

    private void HideTip()
    {
       //tipText.text = default;
       tipWindow.gameObject.SetActive(false); 
    }

    private void OnEnable()
    {
       OnMouseHover +=ShowTip;
       OnMouseLoseFocus += HideTip;
    }
    private void OnDisable()
    {
       OnMouseHover -=ShowTip;
       OnMouseLoseFocus -= HideTip;        
    }


    void Start()
    {
        HideTip();
    }
}
