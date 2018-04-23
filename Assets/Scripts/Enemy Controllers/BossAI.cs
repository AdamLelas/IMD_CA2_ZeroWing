using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {

    //public GameObject ExplosionGO;
    public GameObject target; //the enemy's target
    public GameObject bossGO;
    public GameObject cam;
    public GameObject EnemyBulletGO;
    public Enemy_Fire_Controller e;
    public Transform Boss;
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning

    public int maxRange;
    public int minRange;
    //public float nextFire;
    public float fireRate = 5f;
    public float lastFireTime = 0;
    public float burstDelay = 0;


    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");
        e = GetComponent<Enemy_Fire_Controller>();
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {


        if (target != null)
        {
            //rotate to look at the player
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);

            //move towards the player
            //transform.position += transform.up * Time.deltaTime * moveSpeed;
            if ((Vector3.Distance(transform.position, target.transform.position) < maxRange)
            && (Vector3.Distance(transform.position, target.transform.position) > minRange))
            {
                beginTracking();
                cam.GetComponent<CameraSystem>().setCamSpeed(0f);
                //nextFire = Time.time;
            }

            if (bossGO.GetComponent<EnemyHealth>().getCurHealth() <= 75)
            {
                moveSpeed = 2;
                //bossGO.GetComponent<Enemy_Projectile_Sphere>().AoeShoot();                       
                e.canFire = true;
                if (bossGO.GetComponent<EnemyHealth>().getCurHealth() <= 70)
                {
                    e.GetComponent<Enemy_Fire_Controller>().setFireRate(1);

                    if (bossGO.GetComponent<EnemyHealth>().getCurHealth() <= 60)
                    {
                        e.GetComponent<Enemy_Fire_Controller>().setFireRate(0.5f);


                        if (Time.time > (lastFireTime + burstDelay))
                        {
                            lastFireTime = Time.time;
                            FireEnemyBullet();
                        }

                        if (bossGO.GetComponent<EnemyHealth>().getCurHealth() <= 15)
                        {
                            if(transform.position.y <= 2.3)
                            {
                                transform.Translate(Vector3.up * Time.deltaTime);
                            }

                                if (bossGO.GetComponent<EnemyHealth>().getCurHealth() <= 5)
                            {
                                moveSpeed = 4;
                                minRange = 1;
                            }
                        }
                    }
                }
            }
        

                
            
        }
		     
    }
		
    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            //nextFire = fireRate;

            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

        }
    }
    

    void beginTracking()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);
    }
}
