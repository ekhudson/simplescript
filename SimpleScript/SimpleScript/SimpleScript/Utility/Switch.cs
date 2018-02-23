using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace SimpleScript
{
    public class Switch : SimpleScriptBase
    {
        [SerializeField]
        private bool m_Looping = false;

        [SerializeField]
        private SwitchNode[] m_Nodes;

        private int mCurrentIndex = 0;
        private bool mIsComplete = false;
        private List<int> mIndexList = new List<int>();

        [SerializeField]
        private UnityEvent m_OnComplete;

        private void Start()
        {
            SetupIndexList();
        }

        private void SetupIndexList()
        {
            mIndexList.Clear();

            for (int i = 0; i < m_Nodes.Length; i++)
            {
                mIndexList.Add(i);
            }
        }

        public void Activate()
        {
            if (mIsComplete)
            {
                return;
            }

            CheckAndActivateNode(mCurrentIndex);
            IterateIndex();
        }

        public void SetIndex(int index)
        {
            if (index >= m_Nodes.Length)
            {
                DebugMessage(string.Format("Tried to set index to {0}, but there are only {1} nodes", index, m_Nodes.Length), this);
                return;
            }
            else if (index < 0)
            {
                DebugMessage("Tried to set index to less than zero", this);
                return;
            }

            mCurrentIndex = index;
        }

        public void ActivateAtIndex(int index)
        {
            if (mIsComplete)
            {
                return;
            }

            if (index >= m_Nodes.Length)
            {
                DebugMessage(string.Format("Tried to activate index of {0}, but there are only {1} nodes", index, m_Nodes.Length), this);
                return;            
            }
            else if (index < 0)
            {
                DebugMessage("Tried to activate with an index less than zero", this);
                return;
            }

            mCurrentIndex = index;
            CheckAndActivateNode(index);
            IterateIndex();
        }

        public void Reset()
        {
            mCurrentIndex = 0;
            mIsComplete = false;
            SetupIndexList();
        }

        public void ActivateRandom()
        {
            if (mIsComplete)
            {
                return;
            }

            mCurrentIndex = Random.Range(0, m_Nodes.Length);
            CheckAndActivateNode(mCurrentIndex);
        }

        public void ActivateRandomNonRepeating()
        {
            if (mIsComplete)
            {
                return;
            }

            int indexListIndex = Random.Range(0, mIndexList.Count);

            int actualIndex = mIndexList[indexListIndex];

            mIndexList.RemoveAt(indexListIndex);

            CheckAndActivateNode(actualIndex);

            if (mIndexList.Count <= 0)
            {
                if (m_Looping)
                {
                    SetupIndexList();
                }
                else
                {
                    mIsComplete = true;
                }

                if (m_OnComplete != null)
                {
                    m_OnComplete.Invoke();
                }
            }
        }

        private void IterateIndex()
        {
            if ( (mCurrentIndex + 1) >= m_Nodes.Length)
            {
                if (m_Looping)
                {
                    mCurrentIndex = 0;
                }
                else
                {
                    mIsComplete = true;
                }

                if(m_OnComplete != null)
                {
                    m_OnComplete.Invoke();
                }
            }
            else
            {
                mCurrentIndex += 1;
            }
        }

        private void CheckAndActivateNode(int index)
        {
            if (m_Nodes[index] != null)
            {
                DebugMessage("Activating node at index " + index.ToString(), this);

                m_Nodes[index].OnActivate.Invoke();
            }
            else
            {
                DebugMessage("Tried to activate note at index " + index.ToString() + " , but there was nothing assigned to this node.", this);
            }
        }
    }

    [System.Serializable]
    public class SwitchNode
    {
        [SerializeField]
        private string m_Name;

        [SerializeField]
        private UnityEvent m_OnActivate;

        public UnityEvent OnActivate
        {
            get
            {
                return m_OnActivate;
            }
        }
    }
}
