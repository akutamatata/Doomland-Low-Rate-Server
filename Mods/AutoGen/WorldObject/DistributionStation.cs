namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    
    [Serialized]    
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class DistributionStationObject : 
        StockpileObject, 
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Distribution Station"); } } 

        public override Type RepresentedItemType { get { return typeof(DistributionStationItem); } } 



        protected override void Initialize()
        {
            base.Initialize(); 
            this.GetComponent<MinimapComponent>().Initialize("Economy");                                 


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class DistributionStationItem :
        WorldObjectItem<DistributionStationObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Distribution Station"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A stockpile for distributing items to new players.  Allows you to choose a specific set of items which each new player will be able to take."); } }

        static DistributionStationItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(WoodworkingSkill), 2)]
    public partial class DistributionStationRecipe : Recipe
    {
        public DistributionStationRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DistributionStationItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(WoodworkingEfficiencySkill), 20, WoodworkingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(5, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(DistributionStationRecipe), Item.Get<DistributionStationItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<DistributionStationItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize(Localizer.DoStr("Distribution Station"), typeof(DistributionStationRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}