using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider slider;
    private UIScript script;

    public float hunger = 100.0f;
    private const float coef = 3.33f;

    private void Start()
    {
        script = GetComponentInParent<UIScript>();

    }

    public void SetHunger(float newHunger)
    {
        hunger = newHunger;
        //Debug.Log(hunger);
    }

    private void Update()
    {
        if (hunger > 0)
        {
            if (!script.IsPaused)
            {
                hunger -= coef * Time.deltaTime;

                slider.value = hunger;
            }
        } else
        {
            script.LoseGame(0);
        }

    }
}


