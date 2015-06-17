using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
	public GameObject enemyMapElement;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        GameObject newEnemy = 
			Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
		GameObject newEnemyMapElement = Instantiate (enemyMapElement) as GameObject;
		newEnemyMapElement.GetComponent<MapElement>().target = newEnemy.transform;
		EnemyHealth health = newEnemy.GetComponent<EnemyHealth> ();
		health.myMapElement = newEnemyMapElement;

    }
}
