using System;
using TMPro;
using UnityEngine;

namespace _Root.Scripts.UI
{
    public class DisplayBonuses
    {
        private TMP_Text _text;

        public DisplayBonuses(GameObject bonus)
        {
            _text = bonus.GetComponent<TMP_Text>();
            _text.text = String.Empty;
        }

        public void Display(int value)
        {
            _text.SetText($"You've scored: {value}");
        }
    }
}