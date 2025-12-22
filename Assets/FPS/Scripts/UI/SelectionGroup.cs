using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionGroup : MonoBehaviour
{
    public List<Toggle> toggles;
    private ToggleGroup toggleGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        toggles[GameFlowManager.StartingStage].Select();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnToggleValueChanged(Toggle changedToggle)
    {
        if (changedToggle.isOn)
        {
            GameFlowManager.StartingStage = toggles.IndexOf(changedToggle);
        }
    }
    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
