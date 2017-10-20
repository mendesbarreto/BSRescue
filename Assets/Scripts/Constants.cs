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
        public const string CREDITS = "Credits";
    }
	
    public sealed class TagName
    {
        public const string FLOOR = "Floor";
        public const string PLAYER = "Player";
        public const string BUTTON_START = "ButtonStart";
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
        public const float FUEL_PER_SECONDS = 1f;
    }

    public sealed class Code
    {
        public const string TEXT_RESET = "reset";
        public const string TEXT_CODE = "xj652f8k1";
        public const string TEXT_GAME_STATS = "gameStats";
        public const string TEXT_CODE_INCORRECT = "Codigo incorreto";
        public const string TEXT_MESSAGE_RESET = "RESET - ESTADO: ";
        public const int NUMBER_TO_LOCK_PLAY_BUTTON = 0;
        public const int NUMBER_TO_UNLOCK_PLAY_BUTTON = 1;
    }
}
