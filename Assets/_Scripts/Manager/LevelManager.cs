using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MySingleton<LevelManager> 
{
    public Slider expBar;
    public TMP_Text levelText;

    public float currentExp = 0f;
    public float levelUpExp = 100f;

    //获得经验显示框
    public GameObject levelBox;

    public event Action onLevelUp;
    protected override void Awake()
    {
        base.Awake();
        expBar = GetComponent<Slider>();
        levelText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        expBar.value = Mathf.Lerp(expBar.value,currentExp / levelUpExp,0.01f);
        if(currentExp>= levelUpExp)
        {
            ChangedLevel(1);
        }
    }
    public void ChangedLevel(int level)
    {
        GameManager.Instance.Level += level;
        levelText.text = "Level " + GameManager.Instance.Level;
        currentExp = 0;
        levelUpExp *= 1.5f;
        onLevelUp?.Invoke();
    }

    public void GainExp(Vector2 pos,float exp)
    {
        GameObject go = Instantiate(levelBox, pos, Quaternion.identity);
        go.GetComponentInChildren<TMP_Text>().text = "+" + exp.ToString();

        currentExp += exp;
    }
}
