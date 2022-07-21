using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{
    private Text stats;

    private void Awake()
    {
        stats = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        stats.text = string.Format(
            "killed russians: {0}\n" +
            "$$$: {1}", GoodsHolder.KilledSepars, 0);
    }
}
