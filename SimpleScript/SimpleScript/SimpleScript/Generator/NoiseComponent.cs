using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Simple Script/Generators/Noise")]
public class NoiseComponent : MonoBehaviour
{
    [System.Serializable]
    private class NoiseEvent : UnityEvent<float> { };

    [System.Serializable]
    public class PerlinLayer
    {
        public bool LayerIsMultiplicative = false;
        public float NoiseMagnitude = 1f;
        public float NoiseSpeed = 1f;
    }

    public PerlinLayer[] PerlinLayers;

    [SerializeField]
    private int m_RandomizerAmount = 0;

    [SerializeField]
    private NoiseEvent m_NoiseOutput = new NoiseEvent();
    public void FixedUpdate()
    {
        float timeOffset = Random.Range(-1f, 1f) * m_RandomizerAmount;
        DoNoise(Time.realtimeSinceStartup + timeOffset);
    }

    public void DoNoise(float noiseTime)
    {
        float noiseValue = 0;
        int layerCount = 0;

        foreach (PerlinLayer layer in PerlinLayers)
        {
            float time = noiseTime * layer.NoiseSpeed;
            float tempAmount = 0f;

            tempAmount = Mathf.PerlinNoise(time, 0.0f) * layer.NoiseMagnitude;

            if (layerCount == 0 || !layer.LayerIsMultiplicative)
            {
                noiseValue += tempAmount;

            }
            else
            {
                noiseValue *= tempAmount;
            }

            layerCount++;
        }

        m_NoiseOutput.Invoke(noiseValue);
    }
}