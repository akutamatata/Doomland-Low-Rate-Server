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

    [RequiresSkill(typeof(CastingSkill), 2)]   
    public partial class RivetRecipe : Recipe
    {
        public RivetRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RivetItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(CastingEfficiencySkill), 1, CastingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RivetRecipe), Item.Get<RivetItem>().UILink(), 0.5f, typeof(CastingSpeedSkill));    
            this.Initialize(Localizer.DoStr("Rivet"), typeof(RivetRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }


    [Serialized]
    [Weight(2000)]      
    [Currency]                                              
    public partial class RivetItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Rivet"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A useful steel bolt for holding together inventions."); } }

    }

}