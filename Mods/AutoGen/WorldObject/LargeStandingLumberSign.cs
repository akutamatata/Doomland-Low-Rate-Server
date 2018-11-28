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
    [RequireComponent(typeof(CustomTextComponent))]              
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class LargeStandingLumberSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Standing Lumber Sign"); } } 

        public virtual Type RepresentedItemType { get { return typeof(LargeStandingLumberSignItem); } } 



        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Sign");                                 
            this.GetComponent<CustomTextComponent>().Initialize(700);                                       


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class LargeStandingLumberSignItem :
        WorldObjectItem<LargeStandingLumberSignObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Standing Lumber Sign"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A large sign for all your large text needs!"); } }

        static LargeStandingLumberSignItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(LumberWoodworkingSkill), 3)]
    public partial class LargeStandingLumberSignRecipe : Recipe
    {
        public LargeStandingLumberSignRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeStandingLumberSignItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(LumberWoodworkingEfficiencySkill), 15, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<LumberItem>(typeof(LumberWoodworkingEfficiencySkill), 10, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, LumberWoodworkingSpeedSkill.MultiplicativeStrategy, typeof(LumberWoodworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(LargeStandingLumberSignRecipe), Item.Get<LargeStandingLumberSignItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<LargeStandingLumberSignItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize(Localizer.DoStr("Large Standing Lumber Sign"), typeof(LargeStandingLumberSignRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}