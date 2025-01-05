using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject missionComplete;
    public GameObject missionFail;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void MissionComplete()
    {
        Time.timeScale = 0;
        missionComplete.SetActive(true);
    }

    public void MissionFailed()
    {
        Time.timeScale = 0;
        missionFail.SetActive(true);
    }

    public void OpenScene(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
}
