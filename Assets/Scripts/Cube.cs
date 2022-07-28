using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{

    [SerializeField]
    private GameObject CountingPanel;

    public void getHit(int newValue) {
        CountingPanel.GetComponentsInChildren<Text>()[0].text = "My Current Score: " + newValue;
    }
}
