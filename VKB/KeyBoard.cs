namespace VKB
{
    using System;
    using System.Runtime.InteropServices;

    public class KeyBoard
    {
        public const byte vKey0 = 0x30;
        public const byte vKey1 = 0x31;
        public const byte vKey2 = 50;
        public const byte vKey3 = 0x33;
        public const byte vKey4 = 0x34;
        public const byte vKey5 = 0x35;
        public const byte vKey6 = 0x36;
        public const byte vKey7 = 0x37;
        public const byte vKey8 = 0x38;
        public const byte vKey9 = 0x39;
        public const byte vKeyA = 0x41;
        public const byte vKeyAdd = 0x6b;
        public const byte vKeyAlt = 0x12;
        public const byte vKeyB = 0x42;
        public const byte vKeyBack = 8;
        public const byte vKeyC = 0x43;
        public const byte vKeyCancel = 3;
        public const byte vKeyCapital = 20;
        public const byte vKeyClear = 12;
        public const byte vKeyControl = 0x11;
        public const byte vKeyD = 0x44;
        public const byte vKeyDecimal = 110;
        public const byte vKeyDelete = 0x2e;
        public const byte vKeyDivide = 0x6f;
        public const byte vKeyDown = 40;
        public const byte vKeyE = 0x45;
        public const byte vKeyEnd = 0x23;
        public const byte vKeyEscape = 0x1b;
        public const byte vKeyExecute = 0x2b;
        public const byte vKeyF = 70;
        public const byte vKeyF1 = 0x70;
        public const byte vKeyF10 = 0x79;
        public const byte vKeyF11 = 0x7a;
        public const byte vKeyF12 = 0x7b;
        public const byte vKeyF2 = 0x71;
        public const byte vKeyF3 = 0x72;
        public const byte vKeyF4 = 0x73;
        public const byte vKeyF5 = 0x74;
        public const byte vKeyF6 = 0x75;
        public const byte vKeyF7 = 0x76;
        public const byte vKeyF8 = 0x77;
        public const byte vKeyF9 = 120;
        public const byte vKeyG = 0x47;
        public const byte vKeyH = 0x48;
        public const byte vKeyHelp = 0x2f;
        public const byte vKeyHome = 0x24;
        public const byte vKeyI = 0x49;
        public const byte vKeyJ = 0x4a;
        public const byte vKeyK = 0x4b;
        public const byte vKeyL = 0x4c;
        public const byte vKeyLButton = 1;
        public const byte vKeyLeft = 0x25;
        public const byte vKeyM = 0x4d;
        public const byte vKeyMButton = 4;
        public const byte vKeyMenu = 0x12;
        public const byte vKeyMultiply = 0x6a;
        public const byte vKeyN = 0x4e;
        public const byte vKeyNumlock = 0x90;
        public const byte vKeyNumpad0 = 0x60;
        public const byte vKeyNumpad1 = 0x61;
        public const byte vKeyNumpad2 = 0x62;
        public const byte vKeyNumpad3 = 0x63;
        public const byte vKeyNumpad4 = 100;
        public const byte vKeyNumpad5 = 0x65;
        public const byte vKeyNumpad6 = 0x66;
        public const byte vKeyNumpad7 = 0x67;
        public const byte vKeyNumpad8 = 0x68;
        public const byte vKeyNumpad9 = 0x69;
        public const byte vKeyO = 0x4f;
        public const byte vKeyP = 80;
        public const byte vKeyPageUp = 0x21;
        public const byte vKeyPause = 0x13;
        public const byte vKeyPrint = 0x2a;
        public const byte vKeyQ = 0x51;
        public const byte vKeyR = 0x52;
        public const byte vKeyRButton = 2;
        public const byte vKeyReturn = 13;
        public const byte vKeyRight = 0x27;
        public const byte vKeyS = 0x53;
        public const byte vKeySelect = 0x29;
        public const byte vKeySeparator = 0x6c;
        public const byte vKeyShift = 0x10;
        public const byte vKeySnapshot = 0x2c;
        public const byte vKeySpace = 0x20;
        public const byte vKeySubtract = 0x6d;
        public const byte vKeyT = 0x54;
        public const byte vKeyTab = 9;
        public const byte vKeyU = 0x55;
        public const byte vKeyUp = 0x26;
        public const byte vKeyV = 0x56;
        public const byte vKeyW = 0x57;
        public const byte vKeyX = 0x58;
        public const byte vKeyY = 0x59;
        public const byte vKeyZ = 90;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public static void keyPress(byte keyName)
        {
            keybd_event(keyName, 0, 0, 0);
            keybd_event(keyName, 0, 2, 0);
        }
    }
}

