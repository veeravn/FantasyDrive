using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Maze : MonoBehaviour {
	
	public class Cell {

		public bool visited;
		public GameObject north;
		public GameObject east;
		public GameObject west;
		public GameObject south;
	}
	
	
	public GameObject wall;
	public int xSize = 5;
	public int ySize = 6;
	private float wallLength;
	private Vector3 initialPos;
	private GameObject wallHolder;
	private Cell[] cells;
	private int currentCell = 0;
	private int totalCells;
	private int visitedCells = 0;
	private bool startedBuilding = false;
	private int currentNeighbor = 0;
	private List<int> lastCells;
	private int backingUp = 0;
	private int wallToBreak = 0;
	
	void Start() {
		wallLength = wall.transform.position.y;
		CreateWalls();
	}
	void CreateWalls() {
		wallHolder = new GameObject();
		wallHolder.name = "Maze";
		
		//initialPos = new Vector3((-xSize/2) + wallLength/2, 0f, (-ySize/2) + wallLength/2);
		initialPos = new Vector3(-300f, 0f, -150f);
		Vector3 myPos = initialPos;
		GameObject tempWall;
		
		//Walls for x axis
		for (int i = 0; i < ySize; i++) {
			for (int j = 0; j <= xSize; j++) {
				myPos = new Vector3(initialPos.x + (j*wallLength) - wallLength/2, wallLength, initialPos.z + (i*wallLength) - wallLength/2);
				tempWall = Instantiate(wall, myPos, Quaternion.identity) as GameObject;
				tempWall.transform.parent = wallHolder.transform;
			}
		}
		
		//Walls for y axis
		for (int i = 0; i <= ySize; i++) {
			for (int j = 0; j < xSize; j++) {
				myPos = new Vector3(initialPos.x + (j*wallLength), wallLength, initialPos.z + (i*wallLength) - wallLength);
				tempWall = Instantiate(wall, myPos, Quaternion.Euler(0f, 90f, 0f)) as GameObject;
				tempWall.transform.parent = wallHolder.transform;
			}
		}
		
		CreateCells();
	}
	void CreateCells() {
		lastCells = new List<int>();
		lastCells.Clear();
		totalCells = xSize * ySize;
		GameObject[] allWalls;
		int childWalls = wallHolder.transform.childCount;
		allWalls = new GameObject[childWalls];
		cells = new Cell[xSize*ySize];
		int eastWest = 0; 
		int childProcess = 0;
		int termCount = 0;
		
		//get all children of wallHolder
		for(int i = 0; i < childWalls; i++) {
			allWalls[i] = wallHolder.transform.GetChild(i).gameObject;
		}
		
		//assigns walls to cells
		for (int cellProcess = 0; cellProcess < cells.Length; cellProcess++) {
			if(termCount == xSize) {
				eastWest++;
				termCount = 0;
			} 
			
			cells[cellProcess] = new Cell();
			cells[cellProcess].east = allWalls[eastWest];
			cells[cellProcess].south = allWalls[childProcess+(xSize+1)*ySize];
			eastWest++;
			
			cells[cellProcess].west = allWalls[eastWest];
			cells[cellProcess].north = allWalls[(childProcess+(xSize+1)*ySize) + xSize-1];
			termCount++;
			childProcess++;
		}
		CreateMaze();
	}
	
	void CreateMaze() {
	
		while (visitedCells < totalCells) {
			if(startedBuilding) {
				GetNeighbor();
				if(cells[currentNeighbor].visited == false && cells[currentCell].visited == true) {
					BreakWall();
					cells[currentNeighbor].visited = true;
					visitedCells++;
					lastCells.Add(currentCell);
					currentCell = currentNeighbor;
					if(lastCells.Count > 0) {
						backingUp = lastCells.Count - 1;
					}
				}
			} else {
				currentCell = Random.Range(0, totalCells);
				cells[currentCell].visited = true;
				visitedCells++;
				startedBuilding = true;
			}
		}
	}
	void BreakWall() {
		switch(wallToBreak) {
			case 1: Destroy(cells[currentCell].north);	break;
			case 2: Destroy(cells[currentCell].east); break;
			case 3: Destroy(cells[currentCell].west); break;
			case 4: Destroy(cells[currentCell].south); break;
		
		}
	}
	void GetNeighbor() {
		int length = 0;
		int[] neighbors = new int[4];
		int[] connectingWalls = new int[4];
		int check = 0;
		
		
		check = ((currentCell+1)/xSize );
		check -= 1;
		check *= xSize;
		check += xSize;
		
		//west
		if(currentCell + 1 < totalCells && (currentCell+1) != check) {
			if(cells[currentCell+1].visited == false) {
				neighbors[length] = currentCell + 1;
				connectingWalls[length] = 3;
				length++;
			}	
		}
		
		//east
		if(currentCell - 1 >= 0 && currentCell != check) {
			if(cells[currentCell - 1].visited == false) {
				neighbors[length] = currentCell - 1;
				connectingWalls[length] = 2;
				length++;
			}	
		}
		
		//north
		if(currentCell + xSize < totalCells) {
			if(cells[currentCell + xSize].visited == false) {
				neighbors[length] = currentCell + xSize;
				connectingWalls[length] = 1;
				length++;
			}	
		}
		
		//south
		if(currentCell - xSize >= 0) {
			if(cells[currentCell - xSize].visited ==  false) {
				neighbors[length] = currentCell - xSize;
				connectingWalls[length] = 4;
				length++;
			}	
		}
		
		if(length != 0) {
			int chosen = Random.Range(0, length);
			currentNeighbor = neighbors[chosen];
			wallToBreak = connectingWalls[chosen];
		} else {
			if (backingUp > 0 ){
				currentCell = lastCells[backingUp];
				backingUp--;
			}
		}
	}
}