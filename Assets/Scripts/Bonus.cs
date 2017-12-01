using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    [System.Serializable]
    public class Bonuses
    {
        public GameObject health;
        public GameObject score50;
        public GameObject score25;
        public GameObject score10;
        public GameObject lvlUp;
        public GameObject multishot;
        public GameObject shield;
    }

    public Bonuses bonuses;
    [HideInInspector]
    public int scoreValue = 0;


    public void addBonus(GameObject destrObject)
    {
        GameObject bonus = null;
        int rand = Random.Range(1, 101);
        if (rand >= 1 & rand <= 21)
        {
            int rand2 = Random.Range(1, 101);
            if (rand2 >= 1 & rand2 <= 3)
                bonus = bonuses.health;
            if (rand2 >= 4 & rand2 <= 9)
                bonus = bonuses.lvlUp;
            if (rand2 == 10)
                bonus = bonuses.multishot;
            if (rand2 >= 11 & rand2 <= 35)
            {
                bonus = bonuses.score50;
                scoreValue = 50;
            }
            if (rand2 >= 36 & rand2 <= 60)
            {
                bonus = bonuses.score25;
                scoreValue = 25;
            }
            if (rand2 >= 61 & rand2 <= 90)
            {
                bonus = bonuses.score10;
                scoreValue = 10;
            }
            if (rand2 >= 91 & rand2 <= 101)
                bonus = bonuses.shield;
            Instantiate(bonus, destrObject.GetComponent<Rigidbody>().position, new Quaternion());
        }
    }
}
