using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUltimate : MonoBehaviour
{
    public GameObject ultimatePanel;
    public GameObject speed_Effect;
    public Transform spawn;
    public Button _button;
    public Image _Manabar;
    public float spending = 1f;
    public float _Maxmana = 20f;
    public float _mana;

    private CameraShake _Ultimate;
    

    // Start is called before the first frame update
    void Start()
    {
        _Ultimate = FindObjectOfType<CameraShake>();
        ultimatePanel.SetActive(false);

        _Manabar.fillAmount = 0f;
        _button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpendMana();
    }

    public void PlayUltimate()
    {
        _mana -= _Maxmana;
        ultimatePanel.SetActive(true);
        _Ultimate.Ultimate();
        Instantiate(speed_Effect, spawn.transform.position, Quaternion.identity);
    }

    public void SpendMana()
    {
        if(_mana < 0)
        {
            _mana = 0;
            _button.interactable = false;
        }
        else if(_mana < 20)
        {
            _mana -= spending * Time.deltaTime;
            _Manabar.fillAmount = _mana / _Maxmana;
        }
        else if(_mana == 20)
        {
            _button.interactable = true;
        }
    }

    public void AddMana(float addmana)
    {
        _mana += addmana;
        _Manabar.fillAmount = _mana;

        if(_mana >= 20)
        {
            _mana = 20;
        }
    }
}
