﻿using AlphaECS;
using AlphaECS.Unity;
using UniRx;
using System;

namespace AlphaECS.SurvivalShooter
{
    public class HealthComponent : ComponentBase
	{
        public int StartingHealth;
        public IntReactiveProperty CurrentHealth = new IntReactiveProperty();
        public bool IsDamaged;
//		public BoolReactiveProperty IsDead { get; set; }

		public HealthComponent()
		{
			//CurrentHealth = new IntReactiveProperty ();
//			IsDead = new BoolReactiveProperty ();
		}
	}
}
