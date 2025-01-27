using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIResultBoard : UIBase
{
    private Text score;
    private InputField userName;
    private Button lobbyButton;

    protected override void Init()
    {
        score = Util.FindChild<Text>(gameObject, "ScoreResult");
        userName = Util.FindChild<InputField>(gameObject, "NameInput");
        lobbyButton = Util.FindChild<Button>(gameObject, "LobbyButton");

        lobbyButton.onClick.AddListener(SaveScore);

        CloseUI();
    }

    public void SetScore(int score)
    {
        this.score.text = score.ToString();
    }

    private void SaveScore()
    {
        string songName = GameManager.Instance.songName;
        string userName = this.userName.text;
        int score = int.Parse(this.score.text);

        GameManager.Instance.Ranking.AddRankingEntry(songName, userName, score);

        SceneManager.LoadScene("IntroUIScene");

        CloseUI();
    }
}