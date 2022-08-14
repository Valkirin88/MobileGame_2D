using Tool;
using System;
using UnityEngine;
using JetBrains.Annotations;
using Features.AbilitySystem.Abilities;

using Object = UnityEngine.Object;

namespace Features.AbilitySystem
{
    internal class AbilitiesContext : BaseContext
    {
        private static readonly ResourcePath _dataSourcePath = new ResourcePath("Configs/Ability/AbilityItemConfigDataSource");
        private static readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Ability/AbilitiesView");


        public AbilitiesContext([NotNull] Transform placeForUi, [NotNull] IAbilityActivator activator)
        {
            if (placeForUi == null)
                throw new ArgumentNullException(nameof(placeForUi));

            if (activator == null)
                throw new ArgumentNullException(nameof(activator));

            CreateController(placeForUi, activator);
        }


        private AbilitiesController CreateController(Transform placeForUi, IAbilityActivator activator)
        {
            AbilityItemConfig[] itemConfigs = LoadConfigs();
            AbilitiesRepository repository = CreateRepository(itemConfigs);

            AbilitiesView view = CreateView(placeForUi);
            var controller = new AbilitiesController(view, repository, itemConfigs, activator);

            AddController(controller);

            return controller;
        }

        private AbilitiesView CreateView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<AbilitiesView>();
        }

        private AbilityItemConfig[] LoadConfigs() =>
            ContentDataSourceLoader.LoadAbilityItemConfigs(_dataSourcePath);

        private AbilitiesRepository CreateRepository(AbilityItemConfig[] abilityItemConfigs)
        {
            var repository = new AbilitiesRepository(abilityItemConfigs);
            AddRepository(repository);

            return repository;
        }
    }
}
