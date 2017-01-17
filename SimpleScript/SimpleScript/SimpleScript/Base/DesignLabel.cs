using UnityEngine;

namespace SimpleScript
{
    [System.Serializable]
    public class DesignLabel
    {
        [SerializeField]
        private string m_Text = string.Empty;

        [SerializeField]
        private Color m_Color = Color.clear;

        public string DesignText
        {
            get { return m_Text; }
        }

        public Color DesignColor
        {
            get { return m_Color; }
        }
    }
}
