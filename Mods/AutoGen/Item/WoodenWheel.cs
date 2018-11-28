namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(PrimitiveMechanicsSkill), 1)]   
    public partial class WoodenWheelRecipe : Recipe
    {
        public WoodenWheelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WoodenWheelItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(PrimitiveMechanicsEfficiencySkill), 15, PrimitiveMechanicsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodenWheelRecipe), Item.Get<WoodenWheelItem>().UILink(), 5, typeof(PrimitiveMechanicsSpeedSkill));    
            this.Initialize(Localizer.DoStr("Wooden Wheel"), typeof(WoodenWheelRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class WoodenWheelItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Wooden Wheel"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

    }

}