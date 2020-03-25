using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour {
    [SerializeField] private Rigidbody2D triggerBody;
    [SerializeField] private UnityEvent onTriggerEnter;

    #region MonoBehaviour
    private void Start() {
        AssignPlayerRB();
    }

    void OnTriggerEnter2D(Collider2D other) {
        var hitRb = other.attachedRigidbody;
        if(hitRb == triggerBody) {
            onTriggerEnter.Invoke();
        }
    }
    #endregion

    #region Methods
    private void AssignPlayerRB() {
        if(triggerBody == null) {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if(players.Length == 0) {
                Debug.LogError("No Objects with Tag Player");
                Debug.Break();
            } else if(players.Length > 1) {
                Debug.LogError("Multiple Objects with Tag Player");
                Debug.Break();
            }
            triggerBody = players[0].GetComponent<Rigidbody2D>();
        }
    }
    #endregion
}
