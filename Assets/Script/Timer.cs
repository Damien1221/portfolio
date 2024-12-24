using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timeText;
    public Image _slider;
    public CoolDown _cooldown;
    public float timeLimit = 20f;
    

    private EnemySpawner enemySpawn;
    private float time;
    private bool start_Timer;
    private float multiplierFactor;
    
    // Start is called before the first frame update
    void Start()
    {
        enemySpawn = FindObjectOfType<EnemySpawner>();

        timeText.text = time.ToString();
        _slider.fillAmount = time * multiplierFactor;
        time = timeLimit;

        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!start_Timer) return;

        if (time > 0f && start_Timer && _cooldown.CurrentProgress == CoolDown.Progress.Ready || _cooldown.CurrentProgress == CoolDown.Progress.Finished && time > 0f)
        {
            time -= Time.deltaTime;
            timeText.text = Mathf.CeilToInt(time).ToString();
            _slider.fillAmount = time * multiplierFactor;
        }
        else if (time <= 0f )
        {
            enemySpawn.SpawnAttack();
            RestartTimer();
        }
    }

    public void StartTimer()
    {
        multiplierFactor = 1f / timeLimit;

        time = timeLimit;
        timeText.text = time.ToString();
        start_Timer = true;

        _slider.fillAmount = time * multiplierFactor;
    }

    public void PauseTimer()
    {
        if (_cooldown.CurrentProgress == CoolDown.Progress.Ready && start_Timer)
        {
            start_Timer = false;
            _cooldown.StartCooldown();
        }

        else if (_cooldown.CurrentProgress == CoolDown.Progress.Finished && !start_Timer)
        {
            _cooldown.StopCooldown();
            start_Timer = true;
        }

    }

    public void RestartTimer()
    {
        time = timeLimit;
        timeText.text = time.ToString();
        _slider.fillAmount = time * multiplierFactor;
    }
}
