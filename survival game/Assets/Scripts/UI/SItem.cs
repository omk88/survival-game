using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New SItem",menuName ="SItem/Create New SItem")]

public class SItem : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;

}
//https://www.youtube.com/watch?v=AoD_F1fSFFg , Solo Game Dev ,acessed 11/22 