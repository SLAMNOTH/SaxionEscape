using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    public GameObject door;
    private bool doorDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("door");
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Studiepunten: " + coinCount.ToString();
        if (coinCount >= 45 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}