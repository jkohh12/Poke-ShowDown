using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Sender : MonoBehaviour
{
    [SerializeField] private P1Moves p1Moves;
    
    [DllImport("__Internal")]
    private static extern void SendData(string json);


    [Serializable]
    private struct Info
    {
        public string move1;
        public string move2;
        public string move3;
        public string move4;
    }

    private void Update()
    {
        if(p1Moves.moveSetP1.Count == 4)
        {
            var info = new Info();
            info.move1 = char.ToUpper(p1Moves.moveSetP1[0].name[0]) + p1Moves.moveSetP1[0].name.Substring(1);
            info.move2 = char.ToUpper(p1Moves.moveSetP1[1].name[0]) + p1Moves.moveSetP1[1].name.Substring(1);
            info.move3 = char.ToUpper(p1Moves.moveSetP1[2].name[0]) + p1Moves.moveSetP1[2].name.Substring(1);
            info.move4 = char.ToUpper(p1Moves.moveSetP1[3].name[0]) + p1Moves.moveSetP1[3].name.Substring(1);

            var json = JsonUtility.ToJson(info);
#if !UNITY_EDITOR && UNITY_WEBGL
            SendData(json);
#endif
        }
    }

}
