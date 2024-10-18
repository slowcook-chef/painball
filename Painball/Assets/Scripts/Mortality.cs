using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortality : MonoBehaviour
{
    private int lives = 3;
    [SerializeField] private MortalityDisplay _mortalityDisplay;

    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    private void Start()
    {
        _mortalityDisplay.ShowLife(lives);
    }
    // Start is called before the first frame update
    public void LoseLife()
    {
        if (lives < 0)
        {
            Death();
            return;
        }
        lives--;
        _mortalityDisplay.ShowLife(lives);
    }

    public void Death(){
        // Death Sequence
    }
}
