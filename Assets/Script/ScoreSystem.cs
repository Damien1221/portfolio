using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text _lightingscore;
    public TMP_Text _firescore;
    public TMP_Text _healscore;
    public float current_Light = 0;
    public float current_Fire = 0;
    public float current_Heal = 0;

    // Update is called once per frame
    void Update()
    {
        if (_lightingscore == null)
            return;
        if (_firescore == null)
            return;
        if (_healscore == null)
            return;


        _lightingscore.text = current_Light.ToString();
        _firescore.text = current_Fire.ToString();
        _healscore.text = current_Heal.ToString();


    }

    public void AddScore(float scoreAmount)
    {
        current_Light += scoreAmount;
    }

    public void AddScoreFire(float scoreAmount)
    {
        current_Fire += scoreAmount;
    }

    public void AddScoreHeal(float scoreAmount)
    {
        current_Heal += scoreAmount;
    }


}
