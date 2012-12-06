using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour {
	//the array of all enemies to be spawned at this point, can be anything that extends BasicEnemy
	public BasicEnemy[] enemiesSpawned;
	//the positions to spawn the enemies, if number of positions is less than number of enemies, 
	//script will take turns assigning each one. If empty, script uses own transform
	public Transform[] spawnPoints;
	public bool pausePlayer;
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			
			for(int i = 0; i<enemiesSpawned.Length; i++){
				if(spawnPoints.Length!=0){
					if(i>spawnPoints.Length-1){
						Instantiate(enemiesSpawned[i],spawnPoints[spawnPoints.Length%i].position,enemiesSpawned[i].transform.rotation);
					}
					else{
						Instantiate(enemiesSpawned[i],spawnPoints[i].position,enemiesSpawned[i].transform.rotation);
					}
				}
				else{
					Instantiate(enemiesSpawned[i],transform.position,enemiesSpawned[i].transform.rotation);
				}
			}
			
			
			if(pausePlayer){
				
				GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
				foreach(GameObject player in players){
					Movement mvmt = player.GetComponent("Movement") as Movement;
					if(mvmt!=null){
						mvmt.fixedCamera=true;
					}
					
					Movement2 mvmt2 = player.GetComponent("Movement2") as Movement2;
					if(mvmt2!=null){
						mvmt2.fixedCamera=true;
					}
				}
			}
			
			//Last but not least, destroy this thing
			Destroy(this.gameObject);
		}
	}
	
}
