using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFrame.Runtime;

public class GameEntry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MScene.LoadScene("GameMain");
    }
}
