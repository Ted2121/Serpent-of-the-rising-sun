using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject[] pageObjects = new GameObject[4];
    private int pageNumber = 0;
    public bool IsPaused { get; set; } = true;
    // public Image image;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject startButton;
    [SerializeField]
    private CanvasGroup canvas01;
    [SerializeField]
    private CanvasGroup canvas02;
    [SerializeField]
    private CanvasGroup canvas03;
    public Text loseReasonTxt;
    public Text timeTxt;
    public Text snackScoreTxt;
    public bool gameOver = false;
    float timePlayed = 0;
    public int snacksEaten = 0;
    public Transform underworldObj;

    public void MoveBG()
    {
        underworldObj.position = new Vector3(0, 0, 6f);
    }

    public void NextPage()
    {
        pageNumber++;
        for (int i = 0; i < pageObjects.Length; i++)
        {
            if (pageNumber == i)
            {
                pageObjects[i].SetActive(true);
            } else
            {
                pageObjects[i].SetActive(false);
            }
        }
        UpdateButton();
        prevButton.SetActive(true);
    }


    public void PreviousPage()
    {
        pageNumber--;
        for (int i = 0; i < pageObjects.Length; i++)
        {
            if (pageNumber == i)
            {
                pageObjects[i].SetActive(true);
            }
            else
            {
                pageObjects[i].SetActive(false);
            }
        }
        UpdateButton();
        nextButton.SetActive(true);
    }
    public void UpdateButton()
    {
        if (pageNumber == pageObjects.Length-1)
        {
            nextButton.SetActive(false);

        }
        else if (pageNumber == 0)
        {
            prevButton.SetActive(false);
        }
    }
    public void StartButton()
    {
        canvas01.alpha = 0;
        canvas01.interactable = false;
        canvas01.blocksRaycasts = false;

        canvas02.alpha = 1;
        canvas02.interactable = true;
        canvas02.blocksRaycasts = true;

        this.IsPaused = false;
    }

    public void LoseGame (int loseCon)
    {
        if (gameOver)
        {
            return;
        }
        string loseReason;
        switch (loseCon)
        {
            case 0:
                loseReason = "starved to death";
                break;
            default:
                loseReason = "were caught and turned into a luxury snakeskin purse";
                break;
        }
        loseReasonTxt.text = "You " + loseReason + " :(";

        canvas03.alpha = 1;
        canvas03.interactable = true;
        canvas03.blocksRaycasts = true;

        canvas02.alpha = 0;
        canvas02.interactable = false;
        canvas02.blocksRaycasts = false;

        IsPaused = true;
        gameOver = true;
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (!IsPaused)
        {
            timePlayed += Time.deltaTime;
            int fullSec = Mathf.FloorToInt(timePlayed);
            int minutes = Mathf.FloorToInt(fullSec / 60);
            int seconds = fullSec - minutes * 60;
            timeTxt.text = minutes + ":" + seconds;
            snackScoreTxt.text = snacksEaten.ToString();
        }
    }
}
