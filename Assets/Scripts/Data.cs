using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataKill", menuName = "dataKill", order =1)]

public class Data : ScriptableObject
{
   public int killCount;
   public string previousSceneName;
   public bool isCutscene;
   public int vicoryPreviusScene;
   public int vidaJefe = 5;
}
