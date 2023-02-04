using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BixBite.Combat.Equipables.Weapons
{
	public class RangedWeapons : Weapon
	{
		/// <summary>
		/// This is the value that is set by all the modifiers, and traits to modify the base max ammo amount
		/// </summary>
		private int _maxAmmoModiferOperand = 0;

		private int _maxAmmo = 0;
		public int MaxAmmo
		{
			get => _maxAmmo + _maxAmmoModiferOperand;
			set => _maxAmmo = value;
		}

		public int CurrentAmmo { get; set; }
		public int BulletUsagePer { get; set; }
		
		public void Reload()
		{
			CurrentAmmo = MaxAmmo;
		}

		public bool CanShoot()
		{
			if (BulletUsagePer - CurrentAmmo < 0)
				return false;
			return true;
		}


		public void SetMaxAmmoModiferOperand(int operand)
		{
			_maxAmmoModiferOperand = operand;
		}

		public void SubtractAmmo()
		{
			if (BulletUsagePer - CurrentAmmo < 0)
				CurrentAmmo = 0;
			else CurrentAmmo -= BulletUsagePer;
		}

	}
}
