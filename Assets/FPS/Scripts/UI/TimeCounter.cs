using UnityEngine;
using Unity.FPS.Game;
using TMPro;
using System;

namespace Unity.FPS.UI
{
    public class TimeCounter : MonoBehaviour
    {
        public TextMeshProUGUI timeText;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeText.text = TimeSpan.FromSeconds(GameFlowManager.gameTime).ToString(@"mm\:ss\.ff");
        }
    }
}
