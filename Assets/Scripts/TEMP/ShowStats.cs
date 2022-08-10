using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowStats : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;

    private void FixedUpdate()
    {
        m_Text.text = string.Format("Killed Russians: {0}\n" +
            "Russians per Second: {1}", GoodsHolder.KilledSepars, GoodsHolder.RussiansPerSecond);
    }
}
