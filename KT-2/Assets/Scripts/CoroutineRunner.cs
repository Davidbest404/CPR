using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    [SerializeField] private Wheat_Timer wheatScript;
    [SerializeField] private WheatContibution contibutionScript;
    [SerializeField] private WaveOfEnemies waveOfEnemiesScript;
    public void StartCoroutines()
    {
        StartCoroutine(wheatScript.WheatGive());
        StartCoroutine(contibutionScript.WheatContributionTimerWorking());
        StartCoroutine(waveOfEnemiesScript.TimeUntilNextWave());
    }
    public void StopCoroutines()
    {
        StartCoroutine(wheatScript.WheatGive());
        StartCoroutine(contibutionScript.WheatContributionTimerWorking());
        StartCoroutine(waveOfEnemiesScript.TimeUntilNextWave());
        StopAllCoroutines();
    }


}
