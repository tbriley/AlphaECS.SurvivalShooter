﻿using EcsRx;
using UniRx;
using System;

namespace EcsRx.SurvivalShooter
{
	public class MeleeComponent : IComponent
	{
		public int Damage { get; set; }
		public float AttacksPerSecond { get; set; }
		public IEntity Target { get; set; }
		public BoolReactiveProperty TargetInRange { get; set; }
		public IDisposable Attack { get; set; }
	}
}
