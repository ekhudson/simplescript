using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    public class DelayAction : ActionBase
    {
        [Space]
        [Header("Action Settings")]
        [SerializeField]
        private float m_DelayTimeInSeconds = 0f;

        protected override void ActionLogic()
        {
            StartCoroutine(DoDelay());
        }

        IEnumerator DoDelay()
        {
            if (m_DebugMode)
            {
                Debug.Log(string.Format("Starting delay of {0} seconds", m_DelayTimeInSeconds));
            }

            yield return new WaitForSeconds(m_DelayTimeInSeconds);

            if (m_DebugMode)
            {
                Debug.Log("Delay ended, calling on complete action");
            }

            OnActionComplete();
        }
    }
}