using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    [AddComponentMenu("SimpleScript/Generator/Delta Time")]
    public class DeltaTime : SimpleScriptBase
    {
        public class DeltaTimeEvent : UnityEvent<float> { }

        [SerializeField]
        private UnityEvent<float> m_DeltaTime = new DeltaTimeEvent();

        public void Update()
        {
            m_DeltaTime.Invoke(Time.deltaTime);
        }
    }
}

