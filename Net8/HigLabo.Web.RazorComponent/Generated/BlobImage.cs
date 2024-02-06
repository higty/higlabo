using System;

namespace HigLabo.Web
{
    public enum Higlabo__icon
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
        DragBarPanel__svg,
        Expand__svg,
    }
    public static class Higlabo__icon_Extensions
    {
        public static string GetBlobName(this Higlabo__icon value)
        {
            switch (value)
            {
                case Higlabo__icon.Add__svg: return "icon/Add.svg";
                case Higlabo__icon.ArrowDown__svg: return "icon/ArrowDown.svg";
                case Higlabo__icon.ArrowGlayDown__svg: return "icon/ArrowGlayDown.svg";
                case Higlabo__icon.ArrowGlayLeft__svg: return "icon/ArrowGlayLeft.svg";
                case Higlabo__icon.ArrowGlayRight__svg: return "icon/ArrowGlayRight.svg";
                case Higlabo__icon.ArrowGlayUp__svg: return "icon/ArrowGlayUp.svg";
                case Higlabo__icon.ArrowLeft__svg: return "icon/ArrowLeft.svg";
                case Higlabo__icon.ArrowRight__svg: return "icon/ArrowRight.svg";
                case Higlabo__icon.ArrowRight2__svg: return "icon/ArrowRight2.svg";
                case Higlabo__icon.ArrowUp__svg: return "icon/ArrowUp.svg";
                case Higlabo__icon.Delete__svg: return "icon/Delete.svg";
                case Higlabo__icon.DragBarPanel__svg: return "icon/DragBarPanel.svg";
                case Higlabo__icon.Expand__svg: return "icon/Expand.svg";
                default: throw new InvalidOperationException();
            }
        }
    }
}
