using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlinkingSprite : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI tmpRenderer;
    private float alpha = 1.0f;
    private float blinkSpeed = 2.0f;

    void Update()
    {
        alpha = Mathf.PingPong(Time.time * blinkSpeed, 1.0f);
        Color color = tmpRenderer.color;
        color.a = alpha;
        tmpRenderer.color = color;
    }
}
