namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Gameplay.Objects;

    [Serialized]
    [Weight(100)]                                          
    public partial class CornFrittersItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Corn Fritters"); } }
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Corn Fritters"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("These deep fried corn treats are both crispy and delicious."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 15, Fat = 17, Protein = 7, Vitamins = 8};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 1)]    
    public partial class CornFrittersRecipe : Recipe
    {
        public CornFrittersRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CornFrittersItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornmealItem>(typeof(CulinaryArtsEfficiencySkill), 15, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CornItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<OilItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CornFrittersRecipe), Item.Get<CornFrittersItem>().UILink(), 5, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize(Localizer.DoStr("Corn Fritters"), typeof(CornFrittersRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}