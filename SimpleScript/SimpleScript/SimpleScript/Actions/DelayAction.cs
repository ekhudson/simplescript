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
            yield return new WaitForSeconds(m_DelayTimeInSeconds);
            OnActionComplete();
        }
    }
}