using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript.Actions
{
    public class SimpleAnimationAction : MonoBehaviour
    {
        public enum LoopType
        {
            None,
            Loop,
            PingPong,
        }

        private const float kPlayDirectionForward = 1;
        private const float kPlayDirectionBackward = -1;

        [System.Serializable]
        public class OutputValueEvent : UnityEvent<float> { }
                
        [SerializeField]
        private bool m_StartActive;
        [SerializeField]
        private LoopType m_LoopType = LoopType.None;
        [SerializeField]
        private AnimationCurve m_Animation;

        [SerializeField]
        private OutputValueEvent m_OutputValue;

        private bool mIsAnimating = false;
        private float mCurrentTime = 0f;
        private float mTotalAnimationTime = 0f;
        private float mPlayDirection = kPlayDirectionForward;

        private void Start()
        {
            if (m_StartActive)
            {
                PlayAnimation();
            }
        }

        private void Update()
        {
            if (!mIsAnimating)
            {
                return;
            }

            mTotalAnimationTime = m_Animation[m_Animation.length - 1].time;
            mCurrentTime += (Time.deltaTime * mPlayDirection);

            if (mPlayDirection == kPlayDirectionForward && mCurrentTime > mTotalAnimationTime)
            {
                mCurrentTime = mTotalAnimationTime;
                CompleteAnimation();
            }
            else if (mPlayDirection == kPlayDirectionBackward && mCurrentTime < 0f)
            {
                mCurrentTime = 0f;
                CompleteAnimation();
            }

            float currentValue = m_Animation.Evaluate(mCurrentTime);
            m_OutputValue.Invoke(currentValue);
        }

        public void PlayAnimation()
        {
            mCurrentTime = 0f;
            mIsAnimating = true;
        }

        public void StopAnimation()
        {
            mIsAnimating = false;
            mCurrentTime = 0f;
            mPlayDirection = kPlayDirectionForward;
        }

        public void PauseAnimation()
        {
            mIsAnimating = false;
        }

        private void CompleteAnimation()
        {
            switch(m_LoopType)
            {
                case LoopType.None:
                break;

                case LoopType.Loop:
                    mCurrentTime = 0f;
                break;

                case LoopType.PingPong:
                    mCurrentTime = 0f;
                    mPlayDirection *= -1;
                break;
            }
        }

    }
}
