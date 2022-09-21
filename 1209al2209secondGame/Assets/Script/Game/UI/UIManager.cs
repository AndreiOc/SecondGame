using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI health;
    public TextMeshProUGUI strength;
    public TextMeshProUGUI defense;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI astuteness;
    public TextMeshProUGUI luck;


    public Image healthImage;
    public Image strengthImage;
    public Image defenseImage;
    public Image astutenessImage;
    public Image speedImage;
    public Image luckImage;
    


    public int healthOld;
    public int strengthOld;
    public int defenseOld;
    public int speedOld;
    public int astutenessOld;
    public int luckOld;
        

    [SerializeField][Range(0f,1f)] public float lerpTime;
    PlayerController player;
    public float t = 0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthOld = player.Health;
        strengthOld = player.Strength;
        defenseOld = player.Defense;
        speedOld = player.Speed;
        astutenessOld = player.Astuteness;
        luckOld = player.Luck;
        StatUpdate();
    }

    private void StatUpdate()
    {
        Color currentColor;
        if(player.Health > healthOld)
        {
            currentColor = healthImage.color;
            healthImage.color = Color.Lerp(healthImage.color, Color.magenta,Time.deltaTime * lerpTime);
            t = Mathf.Lerp(t,1f,lerpTime *Time.deltaTime);
            if( t > 0.95f)
            {
                healthImage.color = Color.Lerp(healthImage.color, currentColor,Time.deltaTime * lerpTime);
            }
        }
    }
}
