using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{
	private GameManagerBehavior gameManager;
	public GameObject monsterPrefab;
	private GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool CanPlaceMonster()
	{
	  int cost = monsterPrefab.GetComponent<MonsterData>().levels[0].cost;
	  return monster == null && gameManager.Gold >= cost;

	}
	//tell if we can upgrade
	private bool CanUpgradeMonster()
	{
	  if (monster != null)
	  {
	    MonsterData monsterData = monster.GetComponent<MonsterData>();
	    MonsterLevel nextLevel = monsterData.GetNextLevel();
	    if (nextLevel != null)
	    {
	      return true;
	    }
	  }
	  return false;
	}
	public void print()
	{	
		Debug.Log("grass的数量为: "+gameManager.firms[0]);
		for(int i=1;i<4;i++)
		{
			Debug.Log("第 "+i+" 级别的怪物数量为： "+gameManager.firms[i]);
		}
	}
	void OnMouseUp()
	{

	  //2
	  if (CanPlaceMonster())
	  {
	    //3
	    monster = (GameObject) 
	    Instantiate(monsterPrefab, transform.position, Quaternion.identity);
	    //4
	    AudioSource audioSource = gameObject.GetComponent<AudioSource>();
	    audioSource.PlayOneShot(audioSource.clip);

	    // TODO: Deduct gold
	    gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
	    //increase number of firms
	    gameManager.firms[1]+=1;
	    gameManager.firms[0]-=1;
	    print();

	  }
		else if (CanUpgradeMonster())
		{
		  monster.GetComponent<MonsterData>().IncreaseLevel();
		  AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		  audioSource.PlayOneShot(audioSource.clip);
		  // TODO: Deduct gold
		  gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;

		  //increase the number of firms
		  int i = monster.GetComponent<MonsterData>().levels.IndexOf(monster.GetComponent<MonsterData>().getCurrentLevel());
		  gameManager.firms[i+1]+=1;
		  Debug.Log(gameManager.firms[+1]);
		  //decrease the number of firms
		  gameManager.firms[i]-=1;
		  print();
		  
		}
		else{
			gameManager.firms[3]-=1;
			gameManager.firms[0]+=1;
			print();
			Destroy(monster);
		}
	}
}
