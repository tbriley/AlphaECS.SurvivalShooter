﻿using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Components;
using UniRx;
using UnityEngine;
using Zenject;
using EcsRx.Unity.MonoBehaviours;

namespace EcsRx.SurvivalShooter
{
	public class NavMeshMovementSystem : IReactToGroupSystem
	{
		Transform Target;
		HealthComponent TargetHealth;

		public IGroup TargetGroup
		{
			get 
			{
				return new GroupBuilder ()
					.WithComponent<ViewComponent> ()
					.WithComponent<HealthComponent> ()
					.WithPredicate(x => x.GetComponent<ViewComponent>().View.GetComponent<NavMeshAgent>() != null)
					.Build ();
			}
		}

		public IObservable<GroupAccessor> ReactToGroup (GroupAccessor group)
		{
			return Observable.EveryUpdate().Select(x => @group);
		}

		public void Execute (IEntity entity)
		{
			var navMeshAgent = entity.GetComponent<ViewComponent> ().View.GetComponent<NavMeshAgent> ();
			var health = entity.GetComponent<HealthComponent> ();

			if (Target == null)
			{
				Target = GameObject.FindGameObjectWithTag ("Player").transform;
				if (Target == null)
					return;
				
				TargetHealth = Target.GetComponent<EntityView> ().Entity.GetComponent<HealthComponent>();
				if (TargetHealth == null)
					return;
			}

			if(health.CurrentHealth.Value > 0 && TargetHealth.CurrentHealth.Value > 0)
	        {
				navMeshAgent.SetDestination (Target.position);
	        }
	        else
	        {
				navMeshAgent.enabled = false;
	        }
		}


	}
}
