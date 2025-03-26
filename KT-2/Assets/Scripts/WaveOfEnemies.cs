using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveOfEnemies : MonoBehaviour
{
    [SerializeField] public int enemiesStartAmount;
    [SerializeField] TextMeshProUGUI showingAmountOfTime;
    [SerializeField] TextMeshProUGUI showingAmountOfEnemies;
    [SerializeField] public int currentAmountOfTimeToWave;
    public int startingAmountOfTimeToWave;
    public int enemiesCurrAmount = 0;
    [SerializeField] Wheat_Timer wheatScript;

    void Awake()
    {
        enemiesCurrAmount = enemiesStartAmount;
        startingAmountOfTimeToWave = currentAmountOfTimeToWave;
    }

    public IEnumerator TimeUntilNextWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentAmountOfTimeToWave--;
            Debug.Log(currentAmountOfTimeToWave.ToString());
            if (currentAmountOfTimeToWave <= 0)
            {
                currentAmountOfTimeToWave = startingAmountOfTimeToWave;
                WaveStart();
            }
        }
    }
    void WaveStart()
    {
        if (enemiesCurrAmount <= wheatScript.warriors)
        {
            wheatScript.warriors -= enemiesCurrAmount;
        }
        else
        {   
            wheatScript.civilians -= enemiesCurrAmount * 3 - wheatScript.warriors * 3;
            wheatScript.warriors -= enemiesCurrAmount;
        }
        enemiesCurrAmount += 2;
    }

    void Update()
    {
        showingAmountOfTime.text = currentAmountOfTimeToWave.ToString();
        showingAmountOfEnemies.text = enemiesCurrAmount.ToString();
    }
}
