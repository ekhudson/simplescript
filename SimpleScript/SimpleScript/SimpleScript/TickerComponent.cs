using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    public class TickerComponent : SimpleScriptBase
    {
        [SerializeField]
        private float m_TickRatePerSecond = 60f;
        [SerializeField]
        private bool m_StartsActive = false;

        private bool m_IsActive = false;
        private float m_AccumulatedTicks = 0f;
        private float m_TicksCurrentFrame = 0f;

        [SerializeField]
        private UnityEvent m_OnTick;

        private void Start()
        {
            m_IsActive = m_StartsActive;
        }

        public void StartTicker()
        {
            m_IsActive = true;
        }

        public void StopTicker()
        {
            m_IsActive = false;
        }

        private void Update()
        {
            if (m_IsActive)
            {
                m_TicksCurrentFrame = (m_TickRatePerSecond * Time.deltaTime) + m_AccumulatedTicks;
                m_AccumulatedTicks = 0f;

                if (m_TicksCurrentFrame >= 1f)
                {
                    int actualTicks = Mathf.RoundToInt(m_TicksCurrentFrame);
                    m_AccumulatedTicks = m_TicksCurrentFrame - actualTicks;
                    DoTicks(actualTicks);
                }
                else
                {
                    m_AccumulatedTicks = m_TicksCurrentFrame;
                }
            }
        }

        private void DoTicks(int tickAmount)
        {
            for (int i = 0; i < tickAmount; i++)
            {
                OnTick();
            }
        }

        private void OnTick()
        {
            m_OnTick.Invoke();
        }
    }
}
