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
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class RugLargeObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Rug"); } } 

        public virtual Type RepresentedItemType { get { return typeof(RugLargeItem); } } 



        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Housing");                                 
            this.GetComponent<HousingComponent>().Set(RugLargeItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class RugLargeItem :
        WorldObjectItem<RugLargeObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Rug"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A large area rug to cover that weird stain."); } }

        static RugLargeItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 4,                                   
                                                    TypeForRoomLimit = "Rug", 
                                                    DiminishingReturnPercent = 0.5f    
        };}}
        
    }


    [RequiresSkill(typeof(ClothProductionSkill), 4)]
    public partial class RugLargeRecipe : Recipe
    {
        public RugLargeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RugLargeItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(ClothProductionEfficiencySkill), 20, ClothProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CelluloseFiberItem>(typeof(ClothProductionEfficiencySkill), 15, ClothProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(25, ClothProductionSpeedSkill.MultiplicativeStrategy, typeof(ClothProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(RugLargeRecipe), Item.Get<RugLargeItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<RugLargeItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize(Localizer.DoStr("Rug Large"), typeof(RugLargeRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}