using UnityEngine;

namespace I2.Loc
{
	public static class ScriptLocalization
	{

		public static string you_win__ 		{ get{ return LocalizationManager.GetTranslation ("you win !"); } }
		public static string unlock 		{ get{ return LocalizationManager.GetTranslation ("unlock"); } }
	}

    public static class ScriptTerms
	{

		public const string you_win__ = "you win !";
		public const string unlock = "unlock";
	}
}