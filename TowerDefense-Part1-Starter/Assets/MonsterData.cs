using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; //access to general data structures


[System.Serializable]
public class MonsterLevel
{

  public int cost;
  public GameObject visualization;
  public MonsterLevel(int cost_,GameObject visualization_)
  {
  	cost = cost_;
  	visualization = visualization_;
  }

}

public class MonsterData : MonoBehaviour
{

	private MonsterLevel currentLevel;
	public List<MonsterLevel> levels;
    // Start is called before the first frame update
    public MonsterLevel getCurrentLevel()
    {
    	return currentLevel;
    }
    void Start()
    {
		// myImageComponent = transform.Find("Monster0").gameObject.GetComponent<Image>(); //Our image component is the one attached to this gameObject.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //1
    void OnEnable()
	{
		Transform md = transform.Find("Monster0");
      	levels[0] = new MonsterLevel(200,md.gameObject);
      	Transform md2 = transform.Find("Monster1");
      	levels[1] = new MonsterLevel(110,md2.gameObject);
      	Transform md3 = transform.Find("Monster2");
      	levels[2] = new MonsterLevel(120,md3.gameObject);
      	clearLevel();
      	levels[0].visualization.SetActive(true);
	 	 CurrentLevel = levels[0];
	}
	public void clearLevel()
	{
		for(int i=0;i<3;i++)
     	 {
      		levels[i].visualization.SetActive(false);
     	 }
	}
	//increase the level
	public void IncreaseLevel()
	{
	  int currentLevelIndex = levels.IndexOf(currentLevel);
	  if (currentLevelIndex < levels.Count - 1)
	  {
	    CurrentLevel = levels[currentLevelIndex + 1];
	  }
	}

	public MonsterLevel GetNextLevel()
	{
	  int currentLevelIndex = levels.IndexOf (currentLevel);
	  int maxLevelIndex = levels.Count - 1;
	  if (currentLevelIndex == maxLevelIndex)
	  {
	  	for(int i=0;i<3;i++)
	  	{
	  		Destroy(levels[i].visualization);
	  	}
	  	return null;
	  }
	  if (currentLevelIndex < maxLevelIndex)
	  {
	    return levels[currentLevelIndex+1];
	  } 
	  else
	  {
	    return null;
	  }
	}

	public MonsterLevel CurrentLevel
	{
	  //2
	  get 
	  {
	    return currentLevel;
	  }
	  //3
	  set
	  {
	    currentLevel = value;
	    int currentLevelIndex = levels.IndexOf(currentLevel);

	    GameObject levelVisualization = levels[currentLevelIndex].visualization;
	    for (int i = 0; i < levels.Count; i++)
	    {
	      if (levelVisualization != null) 
	      {
	        if (i == currentLevelIndex) 
	        {
	          levels[i].visualization.SetActive(true);
	        }
	        else
	        {
	          levels[i].visualization.SetActive(false);
	        }
	      }
	    }
	  }
	}

}
