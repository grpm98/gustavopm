using UnityEngine;
using UnityEngine.UI;

public class TimeAndDifficultyIncreaser : MonoBehaviour
{
    public float timeSinceBegginning;
    public int waves = 0;
    public float waveDuration = 10f;
    public float currentWaveTime;
    public Text waveText;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceBegginning += Time.deltaTime;
        currentWaveTime += Time.deltaTime;

        if (currentWaveTime >= waveDuration)
        {
            ChangeWave();
        }

        timerText.text = timeSinceBegginning.ToString("F2");
        waveText.text = "Waves: " + waves.ToString();
    }
    public void ChangeWave()
    {
        currentWaveTime = 0;
        waves += 1;
        waveDuration += 1;
    }
}
