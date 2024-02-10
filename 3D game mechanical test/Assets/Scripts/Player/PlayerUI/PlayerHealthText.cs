using TMPro;
using UnityEngine;

public class PlayerHealthText : MonoBehaviour
{
	[SerializeField] PlayerStatus playerStatus;
	private TextMeshProUGUI playerStatusBar;

	void Start()
	{
		playerStatusBar = GetComponent<TextMeshProUGUI>();
	}

	void Update()
	{
		ShowHealth(playerStatus.playerCurrentHealth, playerStatus.playerMana);
	}

	private void ShowHealth(float health, float mana)
	{
		int healthInt = Mathf.FloorToInt(health);
		int manaInt = Mathf.FloorToInt(mana);
		playerStatusBar.text = string.Format("Health: {0} Mana: {1}", healthInt, manaInt);
	}
}