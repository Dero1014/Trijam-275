using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject[] Screens;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public Transform ClockArrow;
    public Image Clock;
    public Gradient gradientColor;

    public void ShowScreen(int index)
    {
        foreach (var screen in Screens)
        {
            screen.SetActive(false);
        }

        Screens[index].SetActive(true);
    }

    public void UpdateScore(int currentScore)
    {
        ScoreText.text = currentScore.ToString();
    }

    public void UpdateTime(float time, float maxTime)
    {
        Vector3 rotation = new Vector3(0, 0, -time/maxTime * 360);
        Clock.color = gradientColor.Evaluate(time / maxTime);
        ClockArrow.localEulerAngles = rotation;
    }

    public void ShowHighScore(int highScore, int currentScore)
    {
        string[] beginnerText = { "For a beginner not bad", "We are just starting", "You got this!" };
        string[] mediumText = { "Hey, not bad", "Now we are cooking", "My score was 1000" };
        string[] difficultText = { "So that one got you?", "Wow, didn't expect that", "Yoooo, slow down my dude"};
        string[] hardText = { "GODLIKE!", "Hmmm, maybe I should bump up the difficulty", "YOU GOT HOW MUCH?!" };
        string[] betterText = { "Hey, that was better", "I see someone has been studying", "But can you go further?" };
        string scoreBasedText = "";
        int selectedText = Random.Range(-1, 3);

        if (currentScore == 0)
        {
            scoreBasedText = "2+2 is how much...";
        }else if (currentScore <= 10)
        {
            scoreBasedText = beginnerText[selectedText];
        }
        else if(currentScore > 10)
        {
            scoreBasedText = mediumText[selectedText];
        }
        else if (currentScore > 20)
        {
            scoreBasedText = difficultText[selectedText];
        }
        else if (currentScore > 30)
        {
            scoreBasedText = hardText[selectedText];
        }

        if (currentScore > highScore)
        {
            scoreBasedText = betterText[selectedText];
        }

        HighScoreText.text = $"{scoreBasedText}\n\nCURRENT SCORE\n{currentScore}\nHIGH SCORE\n{highScore}\n";
    }
}
