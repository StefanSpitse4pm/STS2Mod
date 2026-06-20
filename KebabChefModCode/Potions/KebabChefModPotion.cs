using BaseLib.Abstracts;
using BaseLib.Utils;
using KebabChefMod.KebabChefModCode.Character;

namespace KebabChefMod.KebabChefModCode.Potions;

[Pool(typeof(KebabChefModPotionPool))]
public abstract class KebabChefModPotion : CustomPotionModel;