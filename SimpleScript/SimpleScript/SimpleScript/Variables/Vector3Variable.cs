using UnityEngine;

namespace SimpleScript
{
    public class Vector3Variable : VariableBase<Vector3>
    {
        public float X { get { return m_Value.x; } set { m_Value.x = m_X = value; } }
        public float Y { get { return m_Value.y; } set { m_Value.y = m_Y = value; } }
        public float Z { get { return m_Value.z; } set { m_Value.z = m_Z = value; } }

        [SerializeField] private float m_X = 0f;
        [SerializeField] private float m_Y = 0f;
        [SerializeField] private float m_Z = 0f;
    }
}


