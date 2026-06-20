using BaseLib.Abstracts;
using KebabChefMod.KebabChefModCode.Extensions;
using Godot;

namespace KebabChefMod.KebabChefModCode.Character;

public class KebabChefModPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => KebabChefMod.Color;


    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}