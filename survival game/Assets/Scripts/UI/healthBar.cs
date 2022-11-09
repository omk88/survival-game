using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour //based on tutorial-add link
{
    public Image FillImage;
    public float CurrentHealth;

    public void UpdateHP()
    {
        FillImage.fillAmount = CurrentHealth / 100;

    }
}
