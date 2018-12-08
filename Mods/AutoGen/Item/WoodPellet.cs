﻿namespace Eco.Mods.TechTree
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

   [RequiresSkill(typeof(LoggingSkill), 1)]   
   public partial class WoodPelletRecipe : Recipe
   {
       public WoodPelletRecipe()
       {
           this.Products = new CraftingElement[]
           {
               new CraftingElement<WoodPelletItem>(2),  
           };
           this.Ingredients = new CraftingElement[]
           {
               new CraftingElement<WoodPulpItem>(typeof(LoggingEfficiencySkill), 10, LoggingEfficiencySkill.MultiplicativeStrategy), 
           };
           this.CraftMinutes = CreateCraftTimeValue(typeof(WoodPelletRecipe), Item.Get<WoodPelletItem>().UILink(), 0.05f, typeof(LoggingDamageSkill));    
           this.Initialize(Localizer.DoStr("Wood Pellets"), typeof(WoodPelletRecipe));

           CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
       }
   }


   [Serialized]
   [Weight(1)]      
   [Fuel(500)][Tag("Fuel")]          
   [Currency]                                              
   public partial class WoodPelletItem :
   Item                                     
   {
       public override LocString DisplayName { get { return Localizer.DoStr("Wood Pellets"); } } 
       public override LocString DisplayDescription { get { return Localizer.DoStr("Can be used as solid fuel."); } }

   }

}
