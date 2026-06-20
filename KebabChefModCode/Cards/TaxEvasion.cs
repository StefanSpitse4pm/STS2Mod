using KebabChefMod.KebabChefModCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

using MegaCrit.Sts2.Core.ValueProps;

namespace KebabChefMod.KebabChefModCode.Cards;

public class TaxEvasion() : KebabChefModCard(0,
    CardType.Skill, CardRarity.Common,
    TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(15, ValueProp.Move)];

    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];


    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        TaxEvasion taxEvasion = this;
        Decimal num = await CreatureCmd.GainBlock(taxEvasion.Owner.Creature, taxEvasion.DynamicVars.Block, play);
    }  

    protected override void OnUpgrade() => DynamicVars.Block.UpgradeValueBy(3M);
}