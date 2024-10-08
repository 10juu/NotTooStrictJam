using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
   public float startWaveLength = 26.0f;
    float startWaveCoolDown = 9.0f;
   public float waveLength = 0.0f;
    float coolDown = 0.0f;
    public int multiplier = 1;
    public bool isWave = true;
    public bool isCoolDown = false;

    public int round;

    public int waveAmount = 0;


    // Start is called before the first frame update
    void Start()
    {
        waveLength = startWaveLength;
        coolDown = startWaveCoolDown;
    }

    // Update is called once per frame
    void Update()
    {

        if (waveAmount > 0)
        //set wave length
        
            SetWave(ref isWave, ref waveLength,  startWaveLength, ref isCoolDown, "isWavey");


        //set wave cooldown
        

         SetWave(ref isCoolDown,ref coolDown,   startWaveCoolDown, ref isWave, "isCool");
         
    }
    public void ResetWave(int amount){
        waveAmount = amount;
        round +=1;
    }
    void SetWave(ref bool condition, ref float time, float startTime, ref bool otherCondition,string phrase){
        if (condition && time > 0f){
            time -= Time.deltaTime;
            Debug.Log(phrase);
        } else if(condition){
           TimeUp( ref condition, ref time,   startTime,  ref otherCondition);
        }
        
    }
    void TimeUp(ref bool condition, ref float time, float startTime, ref bool otherCondition){
        if(condition){
            time = startTime;

            otherCondition = !otherCondition;
            condition = !condition;
            if (!isCoolDown)
                waveAmount -= 1;
        }
    }
}
