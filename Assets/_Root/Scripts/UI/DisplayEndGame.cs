using System;
using _Root.Scripts.Bonus;
using TMPro;
using UnityEngine;

namespace _Root.Scripts.UI
{
    public class DisplayEndGame
    {
        private TMP_Text _finishGameLabel;

        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponent<TMP_Text>();
            _finishGameLabel.text = String.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"You've lost. You've been killed by {name} {color} color";
        }
    }
}