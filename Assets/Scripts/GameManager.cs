using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CinemachineFreeLook cam;
    public UIController uiController;
    public GameObject
        player,
        attackHitbox,
        inventory;
    public HealthBar 
        PlayerHealthBar,
        EnemyHealthBar;
    public List<TextMeshProUGUI>
        potions,
        swords;
    public TextMeshProUGUI powerUp;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
