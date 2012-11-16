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
						Network.Instantiate(enemiesSpawned[i],spawnPoints[spawnPoints.Length%i].position,enemiesSpawned[i].transform.rotation,1);
					}
					else{
						Network.Instantiate(enemiesSpawned[i],spawnPoints[i].position,enemiesSpawned[i].transform.rotation,1);
					}
				}
				else{
					Network.Instantiate(enemiesSpawned[i],transform.position,enemiesSpawned[i].transform.rotation,1);
				}
			}
			
			
			if(pausePlayer){
				Movement mvmt = other.GetComponent("Movement") as Movement;
				if(mvmt!=null){
					mvmt.fixedCamera=true;
				}
			}
			
			//Last but not least, destroy this thing
			Network.Destroy(this.gameObject);
		}
	}
	
}
