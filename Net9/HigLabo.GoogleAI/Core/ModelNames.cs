using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.GoogleAI;

public static class ModelNames
{
    // ===== Gemini LLM =====
    public const string Gemini_2_5_Flash = "gemini-2.5-flash";
    public const string Gemini_2_5_Pro = "gemini-2.5-pro";
    public const string Gemini_2_5_Flash_Lite = "gemini-2.5-flash-lite";

    public const string Gemini_3_Pro_Preview = "gemini-3-pro-preview";
    public const string Gemini_3_Flash_Preview = "gemini-3-flash-preview";
    public const string Gemini_3_1_Pro_Preview = "gemini-3.1-pro-preview";
    public const string Gemini_3_1_Flash_Lite_Preview = "gemini-3.1-flash-lite-preview";

    // ===== Gemini Image =====
    public const string Gemini_3_Pro_Image_Preview = "gemini-3-pro-image-preview";
    public const string Gemini_3_1_Flash_Image_Preview = "gemini-3.1-flash-image-preview";

    // ===== Audio =====
    public const string Gemini_2_5_Flash_Native_Audio = "gemini-2.5-flash-native-audio-latest";
    public const string Gemini_2_5_Flash_Preview_Tts = "gemini-2.5-flash-preview-tts";
    public const string Gemini_2_5_Pro_Preview_Tts = "gemini-2.5-pro-preview-tts";

    // ===== Embedding =====
    public const string Gemini_Embedding_001 = "gemini-embedding-001";

    // ===== Imagen =====
    public const string Imagen_4_Generate = "imagen-4.0-generate-001";
    public const string Imagen_4_Fast = "imagen-4.0-fast-generate-001";
    public const string Imagen_4_Ultra = "imagen-4.0-ultra-generate-001";

    // ===== Veo (Video) =====
    public const string Veo_3_Generate = "veo-3.0-generate-001";
    public const string Veo_3_Fast = "veo-3.0-fast-generate-001";
}