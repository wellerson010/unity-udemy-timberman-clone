using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public void InitGame()
    {
         SoundManager.instance.PlayFX(SoundManager.instance.FxButtonPlay);
        SceneManager.LoadScene("Game");
    }
}
