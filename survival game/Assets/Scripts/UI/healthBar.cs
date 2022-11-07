using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour //https://www.youtube.com/watch?v=2CA5jCnQ5B4, Solo Game Dev ,acessed 11/22 
{
    public Image FillImage;
    public float CurrentHealth;

    public void UpdateHP()
    {
        FillImage.fillAmount = CurrentHealth / 100;

    }
}
