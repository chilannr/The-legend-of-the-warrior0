using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{

    public Image healthImage;
    public Image healthDelayImage;
    public Image powerImage;


    private void Update()
    {
        if (healthDelayImage.fillAmount > healthImage.fillAmount)
        {
            healthDelayImage.fillAmount -= Time.deltaTime*0.9f;
        }
    }
    /// <summary>
    /// ����Health�ı���ٷֱ�
    /// </summary>
    /// <param name="persentage">�ٷֱȣ� current/Max</param>
    public void OnHealthChange(float persentage)
    {
        healthImage.fillAmount = persentage;
    }
}
