using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowStats : MonoBehaviour
{
    private TMP_Text stats;

    private void Awake()
    {
        stats = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        stats.text = string.Format(
            "killed russians: {0}\n" +
            "$$$: {1}", GoodsHolder.KilledSepars, 0);
    }
}
