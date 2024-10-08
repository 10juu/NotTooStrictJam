using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : AbstractFactory//renamed to game manager or spawnmanager
{
    /*

    Length	Cooldown
    26.00 Seconds	9.00 Seconds

    Round 1:
50 enemies
Enemies take 20 seconds to get from the edge of the screen to the center on average (adjust speeds for this)
Common Man - 100 hp, 75% of the time
Knight - 200 hp, 25% of the time

Bow tower
Attack Speed: 1 Second
Damage: 50
(There will be projectiles, spitting out white circles is great for now!)

Canon Tower:
Attack speed: 1.5 seconds
Damage: 75

wave 1
    9 men
    
1 knight
wave 2
9 men

1 knight
wave 3
8 men

2 knights
wave 4
8 men
2 knights

wave 5
5 men
5 knights

    */
    
    public GameObject Player, CommonMan, CommonWoman, Knight, Cannon, Archer, Sword, Axe, mapPosition;
    public IProduct<Enemy> knightFactory, commonFactory, archerFactory;
     public IProduct<TowerFactory> TowerFactory;
    public  WaveManager waveManager;
    
    public List<int> waveList, ogWaveList;
    
    public GameObject [] spawnPoints;

    public int [] upgradeAmount; // cannon100, archer150, sword200, axe250, ball(sword clone), keg(axe clone no boomerang)


    float beginingCommon = 0f;
    float beginingKnight = 0;

    bool isWaiting = false;
    
    // Start is called before the first frame update
    void Start()
    {
       ogWaveList = new List<int>(waveList);
        WaveManager waveManager = (WaveManager.Instance.GetComponent<WaveManager>());
        waveManager.waveAmount = 5;
        //init Factories
        Factory<AbstractFactory.Enemy> enemyFactory = new Factory<Enemy>();
        Factory<AbstractFactory.TowerFactory> towerFactory = new Factory<TowerFactory>();
        //Create Factories
        TowerFactory = towerFactory.Create<Tower>();
        knightFactory = enemyFactory.Create<Knight>();
        commonFactory = enemyFactory.Create<Common>();
        archerFactory = enemyFactory.Create<Archer>();
       //enemyFactory = new factory.Enemy<factory.Knight>();
    }
float resetWaveTime = 0;
float waveTime;
    // Update is called once per frame
    void Update()
    {
    
    if (resetWaveTime == 0 && WaveManager.Instance.waveAmount ==0){
        resetWaveTime = 5f;
    } else if(WaveManager.Instance.waveAmount == 0){
        resetWaveTime -= Time.deltaTime;
        if(resetWaveTime <=0){
            WaveManager.Instance.ResetWave(5);
            waveList = new List<int>(ogWaveList);
        }
    }

    if (WaveManager.Instance.isWave && WaveManager.Instance.waveAmount > 0){
        if (isWaiting && beginingCommon> 0){
            beginingCommon -= Time.deltaTime;

        }
         if (isWaiting && beginingKnight> 0){
            beginingKnight -= Time.deltaTime;
        }
        if(beginingCommon <= 0  && waveList[WaveManager.Instance.waveAmount*2-1]> 0){
            isWaiting = false;
            beginingCommon = Mathf.Floor((float)WaveManager.Instance.waveLength/(float)(waveList[WaveManager.Instance.waveAmount*2-1] ));
        }
         if(beginingKnight<= 0 &&  waveList[WaveManager.Instance.waveAmount*2-1] == 0){
            isWaiting = false;
            beginingKnight= (float)WaveManager.Instance.waveLength/(float)(waveList[WaveManager.Instance.waveAmount*2-2] );
        }
         if (waveList[WaveManager.Instance.waveAmount*2-1] > 0 && !isWaiting && beginingCommon > 0){
        commonFactory.spawn(spawnPoints[0].transform.position, CommonMan, Player);
        waveList[WaveManager.Instance.waveAmount*2-1] -=1;
       
        isWaiting  = true;
    }
     if (waveList[WaveManager.Instance.waveAmount*2-2] > 0 && waveList[WaveManager.Instance.waveAmount*2-1] == 0 && !isWaiting && beginingKnight > 0){
        knightFactory.spawn(spawnPoints[1].transform.position, Knight, Player);
        waveList[WaveManager.Instance.waveAmount*2-2] -=1;
         if(WaveManager.Instance.round %2 == 1){
            archerFactory.spawn(spawnPoints[Random.Range(0,2)].transform.position, Archer,Player);
        }
        isWaiting  = true;
    }


    }

    if(WaveManager.Instance.isCoolDown){
        beginingCommon = 0;
        beginingKnight = 0;
    }
   
      
      
        //SpawnManager spawnmanager = (AbstractFactory.Instance.GetComponent<SpawnManager>());
       
    }
float spawnRange = 3f;
   public void onCannonSpawn(){
        if (UpgradeManager.Instance.playerCoin.coin >=upgradeAmount[0])
            {
                Vector2 position = UpgradeManager.Instance.playerCoin.gameObject.transform.position;
                TowerFactory.spawn(position+new Vector2(Random.Range(-spawnRange, spawnRange),Random.Range(-spawnRange, spawnRange)) , Cannon, mapPosition);

                UpgradeManager.Instance.playerCoin.coin -=upgradeAmount[0];
            }
    }
    public void onTowerSpawn(GameObject prefab, int index){
        if (UpgradeManager.Instance.playerCoin.coin >=upgradeAmount[index])
            {
                Vector2 position = UpgradeManager.Instance.playerCoin.gameObject.transform.position;
                TowerFactory.spawn(position+new Vector2(Random.Range(-spawnRange, spawnRange),Random.Range(-spawnRange, spawnRange)) , prefab, mapPosition);

                UpgradeManager.Instance.playerCoin.coin -=upgradeAmount[index];
            }
    }
    GameObject prefab; 
    int index;
    public void onTowerSpawn(GameObject prefab){
        if (UpgradeManager.Instance.playerCoin.coin >=upgradeAmount[index])
            {
                Vector2 position = UpgradeManager.Instance.playerCoin.gameObject.transform.position;
                TowerFactory.spawn(position+new Vector2(Random.Range(-spawnRange, spawnRange),Random.Range(-spawnRange, spawnRange)) , prefab, mapPosition);

                UpgradeManager.Instance.playerCoin.coin -=upgradeAmount[index];
            }
    }
  
}
