using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int ScoreIncrament;

    public float WaitTime;


    public static GameMaster Instance;

    private UIController _uiController;
    private Calculation _calculation;

    private int _score;
    private int _highScore = 0;
    private float _time = 0;
    private bool _gameStart = false;


    void Start()
    {
        Instance = this;
        _uiController = FindObjectOfType<UIController>();
        _calculation = FindObjectOfType<Calculation>();
    }

    public void SetGame()
    {
        _score = 0;
        _uiController.ShowScreen(1);
        _uiController.UpdateScore(_score);
        _calculation.StartCalculation();
        _calculation.Difficulty(-1, 10, 20);
        _gameStart = true;
    }

    private void Update()
    {
        if (_gameStart)
        {
            Timer();
        }
    }

    public void Score()
    {
        _score += ScoreIncrament;
        _uiController.UpdateScore(_score);
        _time = 0;

        if (_score == 5)
            _calculation.Difficulty(-1, 50, 20);

        if (_score == 10)
            _calculation.Difficulty(-11, 11, 15);

        if (_score == 20)
            _calculation.Difficulty(0, 11, 10, 1);

        if (_score == 25)
            _calculation.Difficulty(-11, 11, 10);

        if (_score == 30)
            _calculation.Difficulty(-51, 51, 5);
    }

    void Timer()
    {
        _time += Time.deltaTime;
        _uiController.UpdateTime(_time, WaitTime);
        if (_time >= WaitTime)
        {
            GameOver();
            _time = 0;
        }
    }


    public void GameOver()
    {
        // Show end screen
        //stop time
        // update & display high score
        _gameStart = false;

        if (_score > _highScore)
        {
            _highScore = _score;
        }

        _uiController.ShowScreen(2);
        _uiController.ShowHighScore(_highScore, _score);
    }
}
