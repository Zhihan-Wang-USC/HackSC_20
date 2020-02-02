using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
	public float Current_A{ get; set; }
	public float Current_B{ get; set; }
	public float Current_C{ get; set; }
	public float MaxVal{ get; set; }
    public double [] pollution = new double[10]; // keep track of pollution
    public string [] pollution_name = {"Carbon dioxide", "Sulfur dioxide", "Nitrogen oxides", "Photochemical smog", "Organic waste", "Nitrates",
		"Pesticide", "Heavy metal", "Soil degradation", "Solid domestic waste"};
    public double [] pollution_change = new double[10]; // keep track of pullution change
    public int back_door_countor{ get; set; }
    public int move{ get; set; }
    public GameObject [] pop_up = new GameObject[8];
    public GameObject [] pop_end = new GameObject[1];
    public static GameObject finder;
    public string[] seasons = {"Winter", "Spring", "Summer", "Fall"};
    public string[] months = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
    public int start_year = 2000;
    // public GameObject pop_up_2;
    // public GameObject pop_up_3;
    // public GameObject pop_up_4;
    // public GameObject pop_up_5;



    public Slider bar_A;
    public Slider bar_B;
    public Slider bar_C;
    //--------------------------------------
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject river;
    [SerializeField]
    private GameObject edge;
    [SerializeField]
    private GameObject tree;
    private GameObject finalObject;
    private Vector2 mousePos;


    public int [] firms = new int[4];
    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    public Text goldLabel;
    public Text repoTitle;
    public Text airrepo;
    public Text waterrepo;
    public Text landrepo;
    public Text repoTitler;
    public Text airrepor;
    public Text curtime;
    private int gold;
    public int Gold {
    	get
    	{ 
    		return gold;
    	}
    	set
    	{
    		gold = value;
    		goldLabel.GetComponent<Text>().text = "Budget: $" + gold;
    	}
    }
    // Start is called before the first frame 
    void Start()
    {

    	GenerateGrid();
		// -----------------
    	MaxVal = 100f;
    	Current_A = MaxVal;
    	Current_B = MaxVal;
    	Current_C = MaxVal;

    	bar_A.value = CalHp_A();
    	bar_B.value = CalHp_B();
    	bar_C.value = CalHp_C();

    	for (int i = 0;i<10;i++){
    		pollution[i] = 10;
    		pollution_change[i] = 0;
    	}
    	for (int i = 0;i<12;i++){
    		pop_up[i].SetActive(false);
    	}

    	int back_door_countor = 0;
    	int move = 0;
    	for(int i=0;i<12;i++)
    	{
    		pop_up[i].SetActive(false);
    	}

    	curtime.GetComponent<Text>().text = months[0] + ", " + start_year;

    }

    private void GenerateGrid()
    {
    	for (int i = -6; i < 7; i++)
    	{
    		for (int j = -11; j < 12; j++)
    		{
    			float posX = j * 2;
    			float posY = i * -2;
    			transform.position = new Vector2(posX, posY);
    			Instantiate(target, transform.position, Quaternion.identity);
    		}
    	}

    	for(int j=0;j<3;j++)
    	{
    		for(int i=0;i<4;i++)
    		{
    			transform.position = new Vector2(2+2*i,-4+j*2);
    			Instantiate(river, transform.position, Quaternion.identity);
    		}
    	}
		// transform.position = new Vector2(2+2*i,-4+j*2);
		// Instantiate(river, transform.position, Quaternion.identity);

    	Gold = 10000;
    	for(int i =0; i < 4;i++)
    	{
    		firms[i] = 0;
    	}
    	firms[0] = 0;


    	for (int i = -5; i < 6; i++)
        {
            for (int j=-8; j < 9;j++)
            {
                if(i==3 || i==2 || j==3 || j==5)
                {
                    float posX = j * 2;
                    float posY = i * 2;
                    transform.position = new Vector2(posX, posY);
                    Instantiate(tree, transform.position, Quaternion.identity);
                }
            }
        }

		for (int i = -5; i < 6; i++)
        {
            for (int j = -8; j < 9; j++)
            {
                if(i == -5 || j == -8 || i==5 || j==8)
                {
                    float posX = j * 2;
                    float posY = i * -2;
                    transform.position = new Vector2(posX, posY);
                    Instantiate(edge, transform.position, Quaternion.identity);
                }   
            }
        }
        /*this is river*/
        transform.position = new Vector2(2, 2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-14, -10);
        Instantiate(river, transform.position, Quaternion.identity); 
        transform.position = new Vector2(-14, -8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-16, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-16, -8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-12, -8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-10, -6);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-8, -4);
        //tode
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-8, -2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-6, 0);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-4, -2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-2, -2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(0, 0);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-16, 0);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-16, 2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-16, 4);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-14, 4);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-14, 2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-16, 6);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-16, 10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-12, 6);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(4, 2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(6, 0);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(8, -2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(10, 2);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(10, 4);
        Instantiate(river, transform.position, Quaternion.identity); 
        transform.position = new Vector2(12, 6);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(14, 4);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(16, 6);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(16, 8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(16, 10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-16, -6);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-12, -6);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(10,0);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(2, -8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(2, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(0, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(4, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(6, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(4, -8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(8, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(12, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(10, -8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(14, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(16, -10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(16, -8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(14, -8);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(16, -6);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(14, 10);
        Instantiate(river, transform.position, Quaternion.identity);
        transform.position = new Vector2(-4, 4);
        Instantiate(river, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    public void hideAll(){
    	back_door_countor=2;
    }

    public void hideAll2(){
    	back_door_countor=3;
    }
        		

    void Update()
    {
    	mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
    	if(back_door_countor==2){
    		// get report title
    		for (int j = 0;j<12;j++){
    			pop_up[j].SetActive(false);
    		}
    		pop_up[1].SetActive(true);
    		repoTitler.GetComponent<Text>().text = "Report as of " + seasons[move % 12 / 3 - 1] + " " + (start_year + (move - 1) / 12);
    		airrepor.GetComponent<Text>().text = "dummy!";


    		Debug.Log("d");
    		back_door_countor=0;
    	}

    	if(back_door_countor==3) {
    		pop_up[1].SetActive(false);
    		pop_up[0].SetActive(false);
    		finder = GameObject.Find("panel88");
    		finder.SetActive(false);
    		Debug.Log("d");
    		back_door_countor=0;
    	}

    	if(Input.GetKeyDown(KeyCode.C)||back_door_countor==1){
    		for (int i = 0;i<12;i++){
    			pop_up[i].SetActive(false);
    		}
    		back_door_countor=0;    		
    		move += 1;
    		curtime.GetComponent<Text>().text = months[move % 12] + ", " + (start_year + (move - 1) / 12);
    		HealthDown_A(-5-firms[1]);
    		HealthDown_B(-firms[2]+9);
    		HealthDown_C(-firms[3]+9);
    		if(true){
    			pollution_change[0] = rand15()/2+0.3*firms[1]+firms[0];
    			pollution_change[1] = rand15()/2+firms[1]+0.3*firms[3];
    			pollution_change[2] = rand15()/2+0.3*firms[1]+firms[3];
    			pollution_change[3] = (float)(0.1*pollution[2]);
    			pollution_change[4] = rand15()/2+firms[3]+0.3*firms[2];
    			pollution_change[5] = rand15()/2+0.1*firms[1]+0.3*firms[3]+firms[2];
    			pollution_change[6] = rand15()/2+firms[2];
    			pollution_change[7] = rand15()/2+firms[1];
    			pollution_change[8] = rand15()/2+0.3*firms[3]+firms[0];
    			pollution_change[9] = rand15()/2+firms[3]+0.3*firms[0];
    		}
    		for (int q = 0; q<10; q++){
    			pollution_change[q] *= 0.7;
    			pollution[q] += pollution_change[q];
    			if(pollution[q]>100){
    				Die();
    			}
    		}
    		Debug.Log("第"+System.Math.Round(pollution[3],1));

    	}

    	if(move==3){
    		pop_up[0].SetActive(true);
    		repoTitle.GetComponent<Text>().text = "Report as of Winter " + (start_year + (move - 1) / 12);
    		airrepo.GetComponent<Text>().text = "";
    		for (int i = 0; i < 4; i++) {
    			airrepo.GetComponent<Text>().text += pollution_name[i] + ": " + System.Math.Round(pollution[i]) + " (";
    			int change = (int)pollution_change[i]*3;
    			if (change >= 0) {airrepo.GetComponent<Text>().text += "+";}
    			airrepo.GetComponent<Text>().text += change + ");\n";
	    	    waterrepo.GetComponent<Text>().text = "";
	    	}
    		for (int j = 4; j < 7; j++) {
    			waterrepo.GetComponent<Text>().text += pollution_name[j] + ": " + System.Math.Round(pollution[j]) + " (";
    			int changer = (int)pollution_change[j]*3;
    			if (changer >= 0) {waterrepo.GetComponent<Text>().text += "+";}
    			waterrepo.GetComponent<Text>().text += changer + ");\n";
    		}
    		landrepo.GetComponent<Text>().text = "";
    		for (int k = 7; k < 10; k++) {
    			landrepo.GetComponent<Text>().text += pollution_name[k] + ": " + System.Math.Round(pollution[k]) + " (";
    			int changet = (int)pollution_change[k]*3;
    			if (changet >= 0) {landrepo.GetComponent<Text>().text += "+";}
    			landrepo.GetComponent<Text>().text += changet + ");\n";
    		}
    	}
    	else if(move==6){
    		pop_up[2].SetActive(true);
    		repoTitle.GetComponent<Text>().text = "Report as of Spring " + (start_year + (move - 1) / 12);
    		airrepo.GetComponent<Text>().text = "";
    		for (int i = 0; i < 4; i++) {
    			airrepo.GetComponent<Text>().text += pollution_name[i] + ": " + System.Math.Round(pollution[i]) + " (";
    			int change = (int)pollution_change[i]*3;
    			if (change >= 0) {airrepo.GetComponent<Text>().text += "+";}
    			airrepo.GetComponent<Text>().text += change + ");\n";
	    	    waterrepo.GetComponent<Text>().text = "";
	    	}
    		for (int j = 4; j < 7; j++) {
    			waterrepo.GetComponent<Text>().text += pollution_name[j] + ": " + System.Math.Round(pollution[j]) + " (";
    			int changer = (int)pollution_change[j]*3;
    			if (changer >= 0) {waterrepo.GetComponent<Text>().text += "+";}
    			waterrepo.GetComponent<Text>().text += changer + ");\n";
    		}
    		landrepo.GetComponent<Text>().text = "";
    		for (int k = 7; k < 10; k++) {
    			landrepo.GetComponent<Text>().text += pollution_name[k] + ": " + System.Math.Round(pollution[k]) + " (";
    			int changet = (int)pollution_change[k]*3;
    			if (changet >= 0) {landrepo.GetComponent<Text>().text += "+";}
    			landrepo.GetComponent<Text>().text += changet + ");\n";
    		}
    	}
    	else if(move==9){
    		pop_up[4].SetActive(true);
    		repoTitle.GetComponent<Text>().text = "Report as of Summer " + (start_year + (move - 1) / 12);
    		    		airrepo.GetComponent<Text>().text = "";
    		for (int i = 0; i < 4; i++) {
    			airrepo.GetComponent<Text>().text += pollution_name[i] + ": " + System.Math.Round(pollution[i]) + " (";
    			int change = (int)pollution_change[i]*3;
    			if (change >= 0) {airrepo.GetComponent<Text>().text += "+";}
    			airrepo.GetComponent<Text>().text += change + ");\n";
	    	    waterrepo.GetComponent<Text>().text = "";
	    	}
    		for (int j = 4; j < 7; j++) {
    			waterrepo.GetComponent<Text>().text += pollution_name[j] + ": " + System.Math.Round(pollution[j]) + " (";
    			int changer = (int)pollution_change[j]*3;
    			if (changer >= 0) {waterrepo.GetComponent<Text>().text += "+";}
    			waterrepo.GetComponent<Text>().text += changer + ");\n";
    		}
    		landrepo.GetComponent<Text>().text = "";
    		for (int k = 7; k < 10; k++) {
    			landrepo.GetComponent<Text>().text += pollution_name[k] + ": " + System.Math.Round(pollution[k]) + " (";
    			int changet = (int)pollution_change[k]*3;
    			if (changet >= 0) {landrepo.GetComponent<Text>().text += "+";}
    			landrepo.GetComponent<Text>().text += changet + ");\n";
    		}
    	}
    	else if(move==12){
    		pop_up[6].SetActive(true);
    		repoTitle.GetComponent<Text>().text = "Report as of Fall " + (start_year + (move - 1) / 12);
    		    		airrepo.GetComponent<Text>().text = "";
    		for (int i = 0; i < 4; i++) {
    			airrepo.GetComponent<Text>().text += pollution_name[i] + ": " + System.Math.Round(pollution[i]) + " (";
    			int change = (int)pollution_change[i]*3;
    			if (change >= 0) {airrepo.GetComponent<Text>().text += "+";}
    			airrepo.GetComponent<Text>().text += change + ");\n";
	    	    waterrepo.GetComponent<Text>().text = "";
	    	}
    		for (int j = 4; j < 7; j++) {
    			waterrepo.GetComponent<Text>().text += pollution_name[j] + ": " + System.Math.Round(pollution[j]) + " (";
    			int changer = (int)pollution_change[j]*3;
    			if (changer >= 0) {waterrepo.GetComponent<Text>().text += "+";}
    			waterrepo.GetComponent<Text>().text += changer + ");\n";
    		}
    		landrepo.GetComponent<Text>().text = "";
    		for (int k = 7; k < 10; k++) {
    			landrepo.GetComponent<Text>().text += pollution_name[k] + ": " + System.Math.Round(pollution[k]) + " (";
    			int changet = (int)pollution_change[k]*3;
    			if (changet >= 0) {landrepo.GetComponent<Text>().text += "+";}
    			landrepo.GetComponent<Text>().text += changet + ");\n";
    		}
    	}

    	else if(move==4){pop_up[9].SetActive(true);}
    	else if(move==7){pop_up[10].SetActive(true);}
    	else if(move==11){pop_up[11].SetActive(true);}
    	else if(move==6){pop_up[12].SetActive(true);}

    }
	// --------
    int rand15(){
    	int randomNumber = Random.Range(0,20);
    	if(randomNumber>=17){
    		randomNumber*=2;
    	}
    	randomNumber-=5;
    	return randomNumber;
    }

    // Update is called once per frame
    public void domove(){
    	back_door_countor=1;
        //goldLabel.SetActive(false);
    }

    public void botton_hide(){
    	for (int i = 0;i<12;i++){
    		pop_up[i].SetActive(false);
    	}
    }

    public void change_A(){
    	Current_A /= 2;
    	pollution[0] -= Current_A*0.2;
    	pollution[1] -= Current_A*0.2;
    	pollution[2] -= Current_A*0.2;
    }

    public void change_B(){
    	Current_A /= 4;
    	pollution[0] -= Current_A;
    	pollution[1] -= Current_A;
    	pollution[2] -= Current_A;
    }

    public void change_C(){
    	Current_A /= 2;
    	pollution[4] -= Current_A*0.3;
    	pollution[9] -= Current_A*0.3;
    }

    public void change_D(){
    	for(int i = 0; i<10; i++){
    		pollution[i] -= Current_A*0.1;
    	}
    }

    public void change_E(){
    	Current_A /= 2;
    	pollution[5] -= Current_A*0.2;
    	pollution[8] -= Current_A*0.2;

    }
        //HealthDown_A/B/C
    void HealthDown_A(float downValue){
    	Current_A -= downValue;
    	bar_A.value = CalHp_A();
    	if (Current_A <= 0){
    		Die();
    	}
    }
    void HealthDown_B(float downValue){
    	Current_B -= downValue;
    	bar_B.value = CalHp_B();
    	if (Current_B <= 0){
    		Die();
    	}
    }
    void HealthDown_C(float downValue){
    	Current_C -= downValue;
    	bar_C.value = CalHp_C();
    	if (Current_C <= 0){
    		Die();
    	}
    }

    // CalHp_A/B/C
    float CalHp_A(){
    	return Current_A/(Current_A+10);
    }
    float CalHp_B(){
    	return Current_B/MaxVal;
    }
    float CalHp_C(){
    	return Current_C/MaxVal;
    }

    void Die(){
    	Debug.Log("You dead.");
    	for(int i = 0; i<1;i++){
    		pop_end[i].SetActive(true);
    	}
    }
}
