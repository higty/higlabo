using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public enum AsciiCharCode : byte
    {
        /// <summary>
        /// 
        /// </summary>
        Null = 0,
        /// <summary>
        /// 
        /// </summary>
        StartOfHeading = 1,
        /// <summary>
        /// 
        /// </summary>
        StartOftext = 2,
        /// <summary>
        /// 
        /// </summary>
        EndOfText = 3,
        /// <summary>
        /// 
        /// </summary>
        EndOfTransmission = 4,
        /// <summary>
        /// 
        /// </summary>
        Enquiry = 5,
        /// <summary>
        /// 
        /// </summary>
        Acknowledge = 6,
        /// <summary>
        /// 
        /// </summary>
        Beli = 7,
        /// <summary>
        /// 
        /// </summary>
        BackSpace = 8,
        /// <summary>
        /// 
        /// </summary>
        HorizontalTabulation = 9,
        /// <summary>
        /// 
        /// </summary>
        LineFeed = 10,
        /// <summary>
        /// 
        /// </summary>
        VerticalTabulation = 11,
        /// <summary>
        /// 
        /// </summary>
        Formfeed = 12,
        /// <summary>
        /// 
        /// </summary>
        CarriageReturn = 13,
        /// <summary>
        /// 
        /// </summary>
        ShiftOut = 14,
        /// <summary>
        /// 
        /// </summary>
        ShiftIn = 15,

        /// <summary>
        /// 
        /// </summary>
        DataLinkEscape = 16,
        /// <summary>
        /// 
        /// </summary>
        DeviceControl1 = 17,
        /// <summary>
        /// 
        /// </summary>
        DeviceControl2 = 18,
        /// <summary>
        /// 
        /// </summary>
        DeviceControl3 = 19,
        /// <summary>
        /// 
        /// </summary>
        DeviceControl4 = 20,
        /// <summary>
        /// 
        /// </summary>
        NegativeAcknowledge = 21,
        /// <summary>
        /// 
        /// </summary>
        SynchronousIdle = 22,
        /// <summary>
        /// 
        /// </summary>
        EndOfTransmissionBlock = 23,
        /// <summary>
        /// 
        /// </summary>
        Cancel = 24,
        /// <summary>
        /// 
        /// </summary>
        EndOfMedium = 25,
        /// <summary>
        /// 
        /// </summary>
        SubstituteCharacter = 26,
        /// <summary>
        /// 
        /// </summary>
        Escape = 27,
        /// <summary>
        /// 
        /// </summary>
        FileSeparator = 28,
        /// <summary>
        /// 
        /// </summary>
        GroupSeparator = 29,
        /// <summary>
        /// 
        /// </summary>
        RecordSeparator = 30,
        /// <summary>
        /// 
        /// </summary>
        UnitSeparator = 31,

        /// <summary>
        /// 
        /// </summary>
        Space = 32,
        /// <summary>
        /// 
        /// </summary>
        ExclamationMark = 33,
        /// <summary>
        /// 
        /// </summary>
        DoubleQuote = 34,
        /// <summary>
        /// 
        /// </summary>
        Sharp = 35,
        /// <summary>
        /// 
        /// </summary>
        Dollar = 36,
        /// <summary>
        /// 
        /// </summary>
        Percent = 37,
        /// <summary>
        /// 
        /// </summary>
        Ampersand = 38,
        /// <summary>
        /// 
        /// </summary>
        SingleQuote = 39,
        /// <summary>
        /// 
        /// </summary>
        LeftBracket = 40,
        /// <summary>
        /// 
        /// </summary>
        RightBracket = 41,
        /// <summary>
        /// 
        /// </summary>
        Asterisk = 42,
        /// <summary>
        /// 
        /// </summary>
        Plus = 43,
        /// <summary>
        /// 
        /// </summary>
        Cumma = 44,
        /// <summary>
        /// 
        /// </summary>
        Minus = 45,
        /// <summary>
        /// 
        /// </summary>
        Period = 46,
        /// <summary>
        /// 
        /// </summary>
        Slash = 47,

        /// <summary>
        /// 
        /// </summary>
        Number0 = 48,
        /// <summary>
        /// 
        /// </summary>
        Number1 = 49,
        /// <summary>
        /// 
        /// </summary>
        Number2 = 50,
        /// <summary>
        /// 
        /// </summary>
        Number3 = 51,
        /// <summary>
        /// 
        /// </summary>
        Number4 = 52,
        /// <summary>
        /// 
        /// </summary>
        Number5 = 53,
        /// <summary>
        /// 
        /// </summary>
        Number6 = 54,
        /// <summary>
        /// 
        /// </summary>
        Number7 = 55,
        /// <summary>
        /// 
        /// </summary>
        Number8 = 56,
        /// <summary>
        /// 
        /// </summary>
        Number9 = 57,
        /// <summary>
        /// 
        /// </summary>
        Colon = 58,
        /// <summary>
        /// 
        /// </summary>
        SemiColon = 59,
        /// <summary>
        /// 
        /// </summary>
        LessThan = 60,
        /// <summary>
        /// 
        /// </summary>
        Equal = 61,
        /// <summary>
        /// 
        /// </summary>
        GreaterThan = 62,
        /// <summary>
        /// 
        /// </summary>
        QuestionMark = 63,

        /// <summary>
        /// 
        /// </summary>
        AtMark = 64,
        /// <summary>
        /// 
        /// </summary>
        A = 65,
        /// <summary>
        /// 
        /// </summary>
        B = 66,
        /// <summary>
        /// 
        /// </summary>
        C = 67,
        /// <summary>
        /// 
        /// </summary>
        D = 68,
        /// <summary>
        /// 
        /// </summary>
        E = 69,
        /// <summary>
        /// 
        /// </summary>
        F = 70,
        /// <summary>
        /// 
        /// </summary>
        G = 71,
        /// <summary>
        /// 
        /// </summary>
        H = 72,
        /// <summary>
        /// 
        /// </summary>
        I = 73,
        /// <summary>
        /// 
        /// </summary>
        J = 74,
        /// <summary>
        /// 
        /// </summary>
        K = 75,
        /// <summary>
        /// 
        /// </summary>
        L = 76,
        /// <summary>
        /// 
        /// </summary>
        M = 77,
        /// <summary>
        /// 
        /// </summary>
        N = 78,
        /// <summary>
        /// 
        /// </summary>
        O = 79,

        /// <summary>
        /// 
        /// </summary>
        P = 80,
        /// <summary>
        /// 
        /// </summary>
        Q = 81,
        /// <summary>
        /// 
        /// </summary>
        R = 82,
        /// <summary>
        /// 
        /// </summary>
        S = 83,
        /// <summary>
        /// 
        /// </summary>
        T = 84,
        /// <summary>
        /// 
        /// </summary>
        U = 85,
        /// <summary>
        /// 
        /// </summary>
        V = 86,
        /// <summary>
        /// 
        /// </summary>
        W = 87,
        /// <summary>
        /// 
        /// </summary>
        X = 88,
        /// <summary>
        /// 
        /// </summary>
        Y = 89,
        /// <summary>
        /// 
        /// </summary>
        Z = 90,
        /// <summary>
        /// 
        /// </summary>
        LeftSquareBracket = 91,
        /// <summary>
        /// 
        /// </summary>
        BackSlash = 92,
        /// <summary>
        /// 
        /// </summary>
        RightSquareBracket = 93,
        /// <summary>
        /// 
        /// </summary>
        Hat = 94,
        /// <summary>
        /// 
        /// </summary>
        UnderBar = 95,

        /// <summary>
        /// 
        /// </summary>
        BackQuote = 96,
        /// <summary>
        /// 
        /// </summary>
        a = 97,
        /// <summary>
        /// 
        /// </summary>
        b = 98,
        /// <summary>
        /// 
        /// </summary>
        c = 99,
        /// <summary>
        /// 
        /// </summary>
        d = 100,
        /// <summary>
        /// 
        /// </summary>
        e = 101,
        /// <summary>
        /// 
        /// </summary>
        f = 102,
        /// <summary>
        /// 
        /// </summary>
        g = 103,
        /// <summary>
        /// 
        /// </summary>
        h = 104,
        /// <summary>
        /// 
        /// </summary>
        i = 105,
        /// <summary>
        /// 
        /// </summary>
        j = 106,
        /// <summary>
        /// 
        /// </summary>
        k = 107,
        /// <summary>
        /// 
        /// </summary>
        l = 108,
        /// <summary>
        /// 
        /// </summary>
        m = 109,
        /// <summary>
        /// 
        /// </summary>
        n = 110,
        /// <summary>
        /// 
        /// </summary>
        o = 111,

        /// <summary>
        /// 
        /// </summary>
        p = 112,
        /// <summary>
        /// 
        /// </summary>
        q = 113,
        /// <summary>
        /// 
        /// </summary>
        r = 114,
        /// <summary>
        /// 
        /// </summary>
        s = 115,
        /// <summary>
        /// 
        /// </summary>
        t = 116,
        /// <summary>
        /// 
        /// </summary>
        u = 117,
        /// <summary>
        /// 
        /// </summary>
        v = 118,
        /// <summary>
        /// 
        /// </summary>
        w = 119,
        /// <summary>
        /// 
        /// </summary>
        x = 120,
        /// <summary>
        /// 
        /// </summary>
        y = 121,
        /// <summary>
        /// 
        /// </summary>
        z = 122,
        /// <summary>
        /// 
        /// </summary>
        LeftCurlyBracket = 123,
        /// <summary>
        /// 
        /// </summary>
        VerticalBar = 124,
        /// <summary>
        /// 
        /// </summary>
        RightCurlyBracket = 125,
        /// <summary>
        /// 
        /// </summary>
        Tilde = 126,
        /// <summary>
        /// 
        /// </summary>
        Delete = 127,
    }
    /// <summary>
    /// 
    /// </summary>
    public static class AsciiCharCodeExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="charCode"></param>
        /// <returns></returns>
        public static Byte GetNumber(this AsciiCharCode charCode)
        {
            return (Byte)charCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="charCode"></param>
        /// <returns></returns>
        public static Char GetChar(this AsciiCharCode charCode)
        {
            return (Char)charCode.GetNumber();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="charCode"></param>
        /// <returns></returns>
        public static String GetString(this AsciiCharCode charCode)
        {
            return GetChar(charCode).ToString();
        }
    }
}
