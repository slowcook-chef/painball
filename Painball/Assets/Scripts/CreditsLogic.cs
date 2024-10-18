using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsLogic : MonoBehaviour
{
    public float scrollSpeed;
    public RectTransform creditsText;
    [SerializeField]private BlinkingSprite blinking;

    void FixedUpdate()
    {
        creditsText.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkDelay(5));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Scene");
        }
    }

    private IEnumerator BlinkDelay(float delay)
    {
        blinking.enabled = false;
        yield return new WaitForSeconds(delay);
        blinking.enabled = true;
    }
}
