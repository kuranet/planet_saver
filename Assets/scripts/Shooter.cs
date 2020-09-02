using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] List<Transform> targetObj;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float orbit;

    [SerializeField] float deltaTimeBetween;
    [SerializeField] float deltaTimeBefore;

    [SerializeField] float maxX;
    [SerializeField] float maxY;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnArrow(deltaTimeBetween, deltaTimeBefore));
    }

    IEnumerator SpawnArrow(float deltaBetween, float deltaBefore)
    {
        while (true)
        {
            int n = Random.Range(0, targetObj.Count);
            Vector3 target = targetObj[n].position;
            Vector3 vel = target - transform.position;
            vel = Vector3.Normalize(vel);
            
            float rot = Vector2.SignedAngle(vel, Vector2.left);
            
            float radius = gameObject.GetComponent<CircleCollider2D>().radius + orbit;
            Vector3 spawnpoin = transform.position + vel*radius;
            spawnpoin.z += 0.1f;

            Quaternion rotation = Quaternion.identity;
            
            rotation = Quaternion.AngleAxis(rot, Vector3.back);
            Debug.DrawLine(transform.position, transform.position + 10 * new Vector3(Mathf.Cos((rot) * Mathf.Deg2Rad), Mathf.Sin((rot) * Mathf.Deg2Rad)));
            
            GameObject bullet = Instantiate(bulletPrefab, spawnpoin, rotation);

            float timePass = 0;
            while(timePass < deltaBefore)
            {
                timePass += Time.deltaTime;

                target = targetObj[n].position;

                Vector3 tempvel = target - transform.position;
                tempvel = Vector3.Normalize(tempvel);

                if (tempvel != vel)
                {
                    spawnpoin = transform.position + tempvel * radius;
                    spawnpoin.z += 0.1f;
                    bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, spawnpoin, 0.1f);

                    bullet.transform.rotation = Quaternion.identity;
                    rot = Vector2.SignedAngle(tempvel, Vector2.left); 
                    rotation = Quaternion.AngleAxis(rot, Vector3.back);
                    bullet.transform.rotation = rotation;
                }
                yield return new WaitForEndOfFrame();
            }

            bullet.transform.position += new Vector3(0, 0, -bullet.transform.position.z);
           
            while (bullet.transform.position.x != target.x && bullet.transform.position.y != target.y)
            {
                bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, target, 0.1f);
                yield return new WaitForEndOfFrame();
            }

            if (bullet.transform.position.x == target.x && bullet.transform.position.y == target.y)
                Destroy(bullet);

            if (Mathf.Abs(bullet.transform.position.x) > maxX || Mathf.Abs(bullet.transform.position.y) > maxY)
                Destroy(bullet);


            yield return new WaitForSeconds(deltaBetween);
        }
    }
}
