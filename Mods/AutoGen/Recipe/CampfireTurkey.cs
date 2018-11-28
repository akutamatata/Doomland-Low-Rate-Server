namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    public class CampfireTurkeyRecipe : Recipe
    {
        public CampfireTurkeyRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(2f),  
               new CraftingElement<TallowItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TurkeyCarcassItem>(1)  
            };
            this.Initialize(Localizer.DoStr("Campfire Turkey"), typeof(CampfireTurkeyRecipe));
            this.CraftMinutes = new ConstantValue(5); 
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}