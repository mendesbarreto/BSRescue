using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Constants 
{
    public sealed class SceneName
    {
        public const string MAIN_MENU = "MainMenu";
        public const string SELECT_LVL = "SelectLvl";
        public const string LVL = "Lvl";
    }
	
    public sealed class TagName
    {
        public const string FLOOR = "Floor";
        public const string PLAYER = "Player";
    }
	
    public sealed class ObjectName
    {
        public const string CAMERA = "MainCamera";
        public const string PLAYER = "Player";
    }

    public sealed class Fuel
    {
        public const float MAX_FUEL = 100f;
        public const float MIN_FUEL = 0f;
        public const float SECONDS_TO_SPEND = .1f;
        public const float NUMBER_ADD_FUEL = 10f;

    }
}
