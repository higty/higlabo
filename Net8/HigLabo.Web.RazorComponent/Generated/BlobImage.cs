using System;

namespace HigLabo.Web
{
    public enum Higlabo__
    {
        Add__svg,
        ArrowDown__svg,
        ArrowGlayDown__svg,
        ArrowGlayLeft__svg,
        ArrowGlayRight__svg,
        ArrowGlayUp__svg,
        ArrowLeft__svg,
        ArrowRight__svg,
        ArrowRight2__svg,
        ArrowUp__svg,
        Delete__svg,
        Expand__svg,
    }
    public static class Higlabo___Extensions
    {
        public static string GetBlobName(this Higlabo__ value)
        {
            switch (value)
            {
                case Higlabo__.Add__svg: return "Add.svg";
                case Higlabo__.ArrowDown__svg: return "ArrowDown.svg";
                case Higlabo__.ArrowGlayDown__svg: return "ArrowGlayDown.svg";
                case Higlabo__.ArrowGlayLeft__svg: return "ArrowGlayLeft.svg";
                case Higlabo__.ArrowGlayRight__svg: return "ArrowGlayRight.svg";
                case Higlabo__.ArrowGlayUp__svg: return "ArrowGlayUp.svg";
                case Higlabo__.ArrowLeft__svg: return "ArrowLeft.svg";
                case Higlabo__.ArrowRight__svg: return "ArrowRight.svg";
                case Higlabo__.ArrowRight2__svg: return "ArrowRight2.svg";
                case Higlabo__.ArrowUp__svg: return "ArrowUp.svg";
                case Higlabo__.Delete__svg: return "Delete.svg";
                case Higlabo__.Expand__svg: return "Expand.svg";
                default: throw new InvalidOperationException();
            }
        }
    }
}
