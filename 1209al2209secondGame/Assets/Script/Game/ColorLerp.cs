using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour
{
    Image imageColor;
    [SerializeField]
    [Range(0,1)] public float speed;

    // Start is called before the first frame update
    private void Awake() 
    {
        imageColor = GetComponent<Image>();    
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangeColor(Color.black));
        if(imageColor.color == Color.black)
            Debug.Log("cc");
    }

    public IEnumerator ChangeColor(Color color)
    {
        imageColor.color = Color.Lerp(imageColor.color, color,speed * Time.deltaTime);
        yield return new WaitForSeconds(0.01f);

    }
}
