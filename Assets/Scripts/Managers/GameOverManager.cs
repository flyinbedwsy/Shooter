using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay  = 5f;

    Animator anim;
	float timer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

			timer += Time.deltaTime;
			if(timer >= restartDelay){
				Application.LoadLevel(Application.loadedLevel);
			}
        }
    }
}
