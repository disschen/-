using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
	public Texture2D img1;
	public Texture2D img2;
	public Texture2D imgBack;
	private int player;
	private int result;
	private int [,] matrix2D;
	private int [] repent;
	
	void OnGUI()
    {
		
		GUI.Label(new Rect(0,0,300,300),"");
		if (GUI.Button(new Rect(200, 0, 100, 50), "restart"))
			Reset();
		if ( result == 0 && GUI.Button(new Rect(200, 50, 100, 50), "repent"))
			Repent();
		else 
			;
		GUIStyle fontStyle = new GUIStyle();  
        fontStyle.normal.background = null;   
        fontStyle.normal.textColor= new Color(1, 0, 1);    
        fontStyle.fontSize = 15;   

		for(int i = 0;i < 3;i ++ ){
			for(int j = 0;j < 3;++ j){
				// if(result != 0) continue;
				if(matrix2D[i,j] == 1)
					GUI.Button(new Rect(50*i, 50*j, 50, 50), img1);
				else if(matrix2D[i,j] == 2)
					GUI.Button(new Rect(50*i, 50*j, 50, 50), img2);
				else if(result != 0){
					if(GUI.Button(new Rect(50*i, 50*j, 50, 50), imgBack))
						;
				}
				else{
					if(GUI.Button(new Rect(50*i, 50*j, 50, 50), imgBack)){
						
						matrix2D[i,j] = 1 + player % 2;
						repent[0] = i; 	repent[1] = j;
						result = check();
						
						player ++;
					}
				}
			}
		} 
		if (result == 1) {    
			GUI.Label (new Rect (200, 100, 100, 50), "Player1 wins!", fontStyle);    
		} else if (result == 2) {    
			GUI.Label (new Rect (200, 100, 100, 50), "Player2 wins!", fontStyle);    
		} else {
			GUI.Label (new Rect (200, 100, 100, 50), "Playing...", fontStyle);
		} 
    }
    // Start is called before the first frame update
    void Start()
    {
		Reset();
		
    }

	void Reset(){
		player = 0;
		result = 0;
		// Debug.Log("12");
		matrix2D = new int [3,3]{
			{0,0,0},
			{0,0,0},
			{0,0,0}
		};
		repent = new int [2] {0,0};
	
	}
	void Repent(){
		player ++;
		matrix2D[repent[0],repent[1]] = 0;
	}
	
	int check(){
		for(int i = 0;i < 3;i ++){
			if(matrix2D[i,0] == matrix2D[i,1] && matrix2D[i,1]== matrix2D[i,2] && matrix2D[i,0] != 0) return matrix2D[i,0];
			if(matrix2D[0,i] == matrix2D[1,i] && matrix2D[1,i]== matrix2D[2,i] && matrix2D[0,i] != 0) return matrix2D[0,i];
		}
		if(matrix2D[0,0] == matrix2D[1,1] && matrix2D[1,1] ==matrix2D[2,2]) return matrix2D[1,1];
		if(matrix2D[0,2] == matrix2D[1,1] && matrix2D[1,1] ==matrix2D[2,0]) return matrix2D[1,1];
		return 0;
	}
    // Update is called once per frame
    void Update(){
        
    }
}
