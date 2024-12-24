using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator _camAnim;
    public Animator _MrStarsDamage;
    public Animator _playerHurt;
    public Animator _MrStarsAttack;
    public Animator _MrStarsReady;
    public Animator _UltimateEffect;


    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
        }
    }

    public void CanShake()
    {
        _camAnim.SetTrigger("shake");
    }

    public void MrStarsDamaging()
    {
        _MrStarsDamage.SetTrigger("MrStars_Damage");
    }

    public void MrStarsAttacking()
    {
        _MrStarsAttack.SetTrigger("MrStars_Attack");
    }

    public void MrStarsReady()
    {
        _MrStarsReady.SetTrigger("MrStars_Ready");
    }

    public void PlayerHurting()
    {
        _playerHurt.SetTrigger("PlayerHurt");
    }

    public void Ultimate()
    {
        _UltimateEffect.SetTrigger("Ultimate_Effect");
    }
}
