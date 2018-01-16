using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text HUDScore;
    public Text HUDBest;

	// Use this for initialization
	void Start () {
        HUDBest.text = PlayerPrefs.GetInt("Record").ToString();
        HUDScore.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void TryAgain()
    {
        SoundManager.instance.PlayFX(SoundManager.instance.FxButtonPlay);
        SceneManager.LoadScene("Game");
    }
}
