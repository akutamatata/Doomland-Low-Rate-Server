namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [RequiresSkill(typeof(MasonSkill), 0)]    
    public partial class GlassworkingSkill : Skill
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Glassworking"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class GlassworkingSkillBook : SkillBook<GlassworkingSkill, GlassworkingSkillScroll>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Glassworking Skill Book"); } }
    }

    [Serialized]
    public partial class GlassworkingSkillScroll : NewSkillScroll<GlassworkingSkill, GlassworkingSkillBook>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Glassworking Skill Scroll"); } }
    }

    [RequiresSkill(typeof(MortaringSkill), 0)] 
    public partial class GlassworkingSkillBookRecipe : Recipe
    {
        public GlassworkingSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GlassworkingSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(ResearchEfficiencySkill), 30, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<MortaredStoneItem>(typeof(ResearchEfficiencySkill), 30, ResearchEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = new ConstantValue(15);

            this.Initialize(Localizer.DoStr("Glassworking Skill Book"), typeof(GlassworkingSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
