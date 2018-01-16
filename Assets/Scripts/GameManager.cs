using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Text HUDScore;
    public Image HUDBarTime;

    public GameObject[] Trunks;
    public List<GameObject> TrunkList;
    public bool GameOver = false;

    private float WidthBarTime = 188f;
    private int Score = 0;
    private float TrunkHeight = 2.43f;//como ta 100 pixel por unit...
    private float InitialPositionY = -2.38f;
    private int MaxTrunks = 6;
    private bool TrunkWithoutBranch = false;
    private float MaxTime = 10;
    private float ExtraTime = 0.115f;
    private float TimeActual;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        TimeActual = MaxTime;
        InitializeTrunk();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            DecreaseBarTime();
        }
    }

    void CreateTrunk(int position)
    {
        SoundManager.instance.PlayFX(SoundManager.instance.FxCut);
        GameObject trunk = (TrunkWithoutBranch) ? Trunks[Random.Range(1, 3)] : Trunks[0];
        trunk = Instantiate(trunk);
        SetTrunkPosition(trunk, position);

        TrunkList.Add(trunk);

        TrunkWithoutBranch = !TrunkWithoutBranch;
    }

    void InitializeTrunk()
    {
        for (int position = 0; position < MaxTrunks; position++)
        {
            CreateTrunk(position);
        }
    }

    void CutTrunk()
    {
        Destroy(TrunkList[0]);
        TrunkList.RemoveAt(0);
        RepositionTrunk();
        CreateTrunk(MaxTrunks - 1);
    }

    void RepositionTrunk()
    {
        for (int position = 0; position < TrunkList.Count; position++)
        {
            SetTrunkPosition(TrunkList[position], position);
        }
    }

    void SetTrunkPosition(GameObject gameObject, int position)
    {
        gameObject.transform.localPosition = new Vector3(0, InitialPositionY + position * TrunkHeight, 0);
    }

    void AddScore()
    {
        Score++;

        HUDScore.text = Score.ToString();
    }

    void AddTime()
    {
        if (TimeActual + ExtraTime < MaxTime)
        {
            TimeActual += ExtraTime;
        }
    }

    void DecreaseBarTime()
    {
        TimeActual -= Time.deltaTime;

        float time = TimeActual / MaxTime;
        float position = WidthBarTime - (time * WidthBarTime);

        HUDBarTime.transform.localPosition = new Vector3(-position, HUDBarTime.transform.localPosition.y, HUDBarTime.transform.localPosition.y);

        if (TimeActual <= 0)
        {
            GameOver = true;
            ScreenGameOver();
        }
    }

    public void ScreenGameOver()
    {
        SoundManager.instance.PlayFX(SoundManager.instance.FxDeath);

        int record = PlayerPrefs.GetInt("Record");
        if (record < Score)
        {
            PlayerPrefs.SetInt("Record", Score);
        }

        PlayerPrefs.SetInt("Score", Score);

        Invoke("ScreenGameOverInvoke", 2);
    }

    private void ScreenGameOverInvoke()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Touch()
    {
        if (!GameOver) { 
        CutTrunk();

            AddScore();
            AddTime();
            RepositionTrunk();
        }
    }
}
