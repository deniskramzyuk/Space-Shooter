using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    [System.Serializable]
    public class Bonuses
    {
        public GameObject health;
        public GameObject score50;
    }

    public Bonuses bonuses;

    public void addBonus(GameObject destrObject)
    {
        GameObject bonus = null;
        int rand = Random.Range(1, 100);
        if (rand >= 1 & rand <= 5)
        {
            int rand2 = Random.Range(1, 100);
            if (rand2 >= 1 & rand2 <= 50) bonus = bonuses.health;
            if (rand2 >= 51 & rand2 <= 100) bonus = bonuses.score50;
            Instantiate(bonus, destrObject.GetComponent<Rigidbody>().position, new Quaternion());
        }
    }
}
