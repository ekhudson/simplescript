using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    [AddComponentMenu("SimpleScript/Generator/Time Since Startup")]
    public class TimeSinceStartup : SimpleScriptBase
    {
        public class TimeSinceStartupEvent : UnityEvent<float>{}

        [SerializeField]
        private TimeSinceStartupEvent m_TimeSinceStartup = new TimeSinceStartupEvent();

        public void Update()
        { 
            m_TimeSinceStartup.Invoke(Time.time);
        }
    }
}

