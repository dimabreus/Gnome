using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public abstract class CreatureController : MonoBehaviour
{
	[SerializeField] private ushort _health = 100;
	[SerializeField] private ushort _maxHealth = 100;
	[SerializeField] protected float speedDefault = 5;
	[SerializeField] protected float speedSprint = 7;

	protected Rigidbody2D rb;

	// TODO: Add effects
	//private Effects.Effect[] _effects;

	public abstract void Death();
	public abstract void Move();

	protected virtual void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

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
	public ushort MaxHealth => _maxHealth;
}
