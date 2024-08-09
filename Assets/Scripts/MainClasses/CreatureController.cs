using UnityEngine;

public abstract class CreatureController : MonoBehaviour
{
	[SerializeField] private ushort _health;
	[SerializeField] private ushort _maxHealth;
	[SerializeField] private float _speed;
	[SerializeField] private float _agrSpeed;

	private Effects.Effect[] _effects;

	public abstract void Death();
	public abstract void Move();

	private void Update()
	{
		if (IsDeath) return;

		ActionUpdate();
	}
	protected virtual void ActionUpdate()
	{
		Move();
	}


	public virtual void GetDamage(ushort damage)
	{
		if (_health - damage < 0)
		{
			_health = 0;
			Death();
			return;
		}

		_health -= damage;
	}
	public virtual void Healing(ushort healingPoint)
	{
		_health = (ushort)Mathf.Min(_health + healingPoint, _maxHealth);
	}


	private void OnValidate()
	{
		_health = (ushort)Mathf.Min(_health, _maxHealth);
	}


	public bool IsDeath => _health == 0;
}
