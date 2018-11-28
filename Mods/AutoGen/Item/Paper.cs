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

    [RequiresSkill(typeof(PaperSkill), 1)]   
    public partial class PaperRecipe : Recipe
    {
        public PaperRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PaperItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PaperPulpItem>(typeof(PaperEfficiencySkill), 4, PaperEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaperRecipe), Item.Get<PaperItem>().UILink(), 0.25f, typeof(PaperSpeedSkill));    
            this.Initialize(Localizer.DoStr("Paper"), typeof(PaperRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [Weight(100)]      
    [Currency]                                              
    public partial class PaperItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Paper"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("It's paper."); } }

    }

}