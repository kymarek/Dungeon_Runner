using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float speed;
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private GameObject _trap;
    [SerializeField] private float _spawnChanceTrap;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform point in _points)
        {
            float generatedValue = Random.value;
            if (generatedValue <= _spawnChanceTrap) 
            {
                GameObject newTrap = Instantiate(_trap, point.position - new Vector3(0, 0.4f, 0), Quaternion.identity);
                newTrap.transform.SetParent(transform, true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
    }
}
