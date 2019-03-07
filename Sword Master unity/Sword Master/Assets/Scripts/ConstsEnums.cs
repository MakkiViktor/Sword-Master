using System.Collections.Generic;

namespace ConstsEnums {

    public enum AnimationStates
    {
        VOID = -1,
        IDLE = 0, 
        MOVE = 1,
        SWITCH = 2
    }

    public enum InputSettings {
       MOVEX,
       MOVEY,
       LOOKX,
       LOOKY,
       SWITCH,
    }

    //Az összes név a PlayerOverrideControllerből
    public static class AnimationClipNames {
        public const string BodyIdleR = "Armature|BodyIdle.R";
        public const string BodyIdleL = "Armature|BodyIdle.R";
    }

    public static class AnimatorParameters {
        public const string MoveX = "Move X";
        public const string MoveY = "Move Y";
        public const string AnimationState = "AnimationState";
        public const string StanceSide = "StanceSide";
    }

    public static class Controller {
        public const string LeftStickX = "Left Stick X";
        public const string LeftStickY = "Left Stick Y";
        public const string RightStickX = "Right Stick X";
        public const string RightStickY = "Right Stick Y";
        public const string XButton = "X Button";
        public const string OButton = "O Button";
        public const string SquareButton = "Square Button";
        public const string TriangleButton = "Triangle Button";
        public const string L1Button = "L1 Button";
        public const string R1Button = "R1 Button";
        public const string L2Button = "L2 Button";
        public const string R2Button = "R2 Button";
        public const string L3Button = "L3 Button";
        public const string R3Button = "R3 Button";
        public const string OptionButton = "Option Button";
        public const string DPADX = "DPAD X";
        public const string DPADY = "DPAD Y";

        //Ez nem bemenet, a nyilak megkülönbözttetéséhez kell
        public const string DPADUp = "DPAD Up";
        public const string DPADDown = "DPAD Down";
        public const string DPADRight = "DPAD Right";
        public const string DPADLeft = "DPAD Left";

    }
}