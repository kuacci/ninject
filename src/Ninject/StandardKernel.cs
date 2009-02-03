﻿using System;
using Ninject.Activation;
using Ninject.Activation.Caching;
using Ninject.Activation.Strategies;
using Ninject.Injection;
using Ninject.Interception;
using Ninject.Modules;
using Ninject.Planning;
using Ninject.Planning.Strategies;
using Ninject.Resolution;
using Ninject.Resolution.Strategies;
using Ninject.Selection;
using Ninject.Selection.Heuristics;

namespace Ninject
{
	public class StandardKernel : KernelBase
	{
		public StandardKernel(params IModule[] modules)
			: base(modules)
		{
			AddComponents();
		}

		public StandardKernel(INinjectSettings settings, params IModule[] modules)
			: base(settings, modules)
		{
			AddComponents();
		}

		private void AddComponents()
		{
			Components.Add<IPipeline, Pipeline>();
			Components.Add<IActivationStrategy, PropertyInjectionStrategy>();
			Components.Add<IActivationStrategy, MethodInjectionStrategy>();
			Components.Add<IActivationStrategy, InitializableStrategy>();
			Components.Add<IActivationStrategy, StartableStrategy>();
			Components.Add<IActivationStrategy, DisposableStrategy>();

			Components.Add<ICache, Cache>();
			Components.Add<ICachePruner, CachePruner>();

			Components.Add<IPlanner, Planner>();
			Components.Add<IPlanningStrategy, ConstructorReflectionStrategy>();
			Components.Add<IPlanningStrategy, PropertyReflectionStrategy>();
			Components.Add<IPlanningStrategy, MethodReflectionStrategy>();

			Components.Add<ISelector, Selector>();
			Components.Add<IConstructorScorer, StandardConstructorScorer>();
			Components.Add<IPropertyInjectionHeuristic, StandardPropertyInjectionHeuristic>();
			Components.Add<IMethodInjectionHeuristic, StandardMethodInjectionHeuristic>();
			Components.Add<IMethodInterceptionHeuristic, StandardMethodInterceptionHeuristic>();
			Components.Add<IInjectorFactory, StandardInjectorFactory>();

			Components.Add<IResolver, Resolver>();
			Components.Add<IResolutionStrategy, KernelResolutionStrategy>();
			Components.Add<IResolutionStrategy, ComponentResolutionStrategy>();

			Components.Add<IAdviceRegistry, AdviceRegistry>();
		}
	}
}