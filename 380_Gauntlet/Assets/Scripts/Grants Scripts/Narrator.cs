using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public AudioSource firstHit, keyPickup, stickThrown, foodPickup, potionPickup, treasurePickup, level1, level2, level3, lowOnHealth, warrior, wizard, valkyrie, elf;

    private AudioSource playerType;
    private PlayerSO _playerSO;
    private PlayerMovement _player;
    private static bool _isFirstHit = true;
    private static bool _isFirstKey = true;
    private static bool _isFirstAttack = true;
    private static bool _isFirstPotion = true;
    private static bool _isFirstTreasure = true;
    private static bool _isFirstFood = true;
    private static bool _isFirstMovement = true;
    private bool _canWarn = true;

    private void Awake()
    {
        _player = gameObject.GetComponent<PlayerMovement>();
        _playerSO = _player.BasePlayer;

        switch (_playerSO.name)
        {
            case "Elf":
                playerType = elf;
                break;

            case "Valkyrie":
                playerType = valkyrie;
                break;

            case "Wizard":
                playerType = wizard;
                break;

            case "Warrior":
                playerType = warrior;
                break;

            default:
                Debug.Log("Player Type: " + _playerSO.name);
                break;
        }
    }

    private void Update()
    {
        if (_player.isThrowing && _isFirstAttack)
        {
            _isFirstAttack = false;
            stickThrown.Play();
        }

        if(_player.playerHealth < 200)
        {
            if (_canWarn)
            {
                _canWarn = false;
                StartCoroutine(HealthWarning());               
            }            
        }

        if (_player.playerHealth > 200)
            _canWarn = true;

        if (_player.isMoving && _isFirstMovement)
        {
            _isFirstMovement = false;
            level1.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<EnemyMovement>())
        {
            if (_isFirstHit)
            {
                _isFirstHit = false;
                firstHit.Play();
            }
        }

        if (collision.collider.gameObject.CompareTag("Level1"))
        {
            level2.Play();
        }

        if (collision.collider.gameObject.CompareTag("Level2"))
        {
            level3.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            if (_isFirstKey)
            {
                _isFirstKey = false;
                keyPickup.Play();
            }
        }

        if (other.gameObject.CompareTag("Potion"))
        {
            if (_isFirstPotion)
            {
                _isFirstPotion = false;
                potionPickup.Play();
            }
        }

        if (other.gameObject.CompareTag("Treasure"))
        {
            if (_isFirstTreasure)
            {
                _isFirstTreasure = false;
                treasurePickup.Play();
            }
        }

        if (other.gameObject.CompareTag("Food"))
        {
            if (_isFirstFood)
            {
                _isFirstFood = false;
                foodPickup.Play();
            }
        }
    }


    private IEnumerator HealthWarning()
    {
        playerType.Play();
        yield return new WaitForSeconds(playerType.clip.length);
        lowOnHealth.Play();
    }
}
