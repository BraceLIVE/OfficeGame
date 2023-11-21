using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaCount : MonoBehaviour
{
    public static PizzaCount instance;

    private Text textObj;

    public int counterValue = 5;

    void Awake()
    {
        // Singleton-Implementierung
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        textObj = gameObject.GetComponent<Text>();
        UpdateCounterText();
    }

    public void IncreaseCounter()
    {
        counterValue++;
        UpdateCounterText();
    }

    public void DecreaseCounter()
    {
        counterValue--;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        textObj.text = "Pizza: " + counterValue.ToString();
    }
}
