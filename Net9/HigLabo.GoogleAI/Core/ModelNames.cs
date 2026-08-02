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
    public const string Gemini_2_5_Flash_Lite_Preview_09_2025 = "gemini-2.5-flash-lite-preview-09-2025";

    public const string Gemini_3_6_Flash = "gemini-3.6-flash";
    public const string Gemini_3_5_Flash = "gemini-3.5-flash";
    public const string Gemini_3_5_Flash_Lite = "gemini-3.5-flash-lite";
    public const string Gemini_3_Pro_Preview = "gemini-3-pro-preview";
    public const string Gemini_3_Flash_Preview = "gemini-3-flash-preview";
    public const string Gemini_3_1_Pro_Preview = "gemini-3.1-pro-preview";
    public const string Gemini_3_1_Pro_Preview_CustomTools = "gemini-3.1-pro-preview-customtools";
    public const string Gemini_3_1_Flash_Lite = "gemini-3.1-flash-lite";
    public const string Gemini_3_1_Flash_Lite_Preview = "gemini-3.1-flash-lite-preview";

    // ===== Gemini Image =====
    public const string Gemini_3_Pro_Image = "gemini-3-pro-image";
    public const string Gemini_3_Pro_Image_Preview = "gemini-3-pro-image-preview";
    public const string Gemini_3_1_Flash_Image = "gemini-3.1-flash-image";
    public const string Gemini_3_1_Flash_Lite_Image = "gemini-3.1-flash-lite-image";
    public const string Gemini_3_1_Flash_Image_Preview = "gemini-3.1-flash-image-preview";
    public const string Gemini_2_5_Flash_Image = "gemini-2.5-flash-image";
    public const string Gemini_Omni_Flash_Preview = "gemini-omni-flash-preview";

    // ===== Audio =====
    public const string Gemini_3_5_Live_Translate_Preview = "gemini-3.5-live-translate-preview";
    public const string Gemini_3_1_Flash_Live_Preview = "gemini-3.1-flash-live-preview";
    public const string Gemini_3_1_Flash_Tts_Preview = "gemini-3.1-flash-tts-preview";
    public const string Gemini_2_5_Flash_Native_Audio = "gemini-2.5-flash-native-audio-latest";
    public const string Gemini_2_5_Flash_Native_Audio_Preview_12_2025 = "gemini-2.5-flash-native-audio-preview-12-2025";
    public const string Gemini_2_5_Flash_Preview_Tts = "gemini-2.5-flash-preview-tts";
    public const string Gemini_2_5_Pro_Preview_Tts = "gemini-2.5-pro-preview-tts";

    // ===== Embedding =====
    public const string Gemini_Embedding_2 = "gemini-embedding-2";
    public const string Gemini_Embedding_001 = "gemini-embedding-001";

    // ===== Robotics =====
    public const string Gemini_Robotics_ER_2_Preview = "gemini-robotics-er-2-preview";
    public const string Gemini_Robotics_ER_2_Streaming_Preview = "gemini-robotics-er-2-streaming-preview";

    // ===== Imagen =====
    public const string Imagen_4_Generate = "imagen-4.0-generate-001";
    public const string Imagen_4_Fast = "imagen-4.0-fast-generate-001";
    public const string Imagen_4_Ultra = "imagen-4.0-ultra-generate-001";

    // ===== Veo (Video) =====
    public const string Veo_3_1_Generate_Preview = "veo-3.1-generate-preview";
    public const string Veo_3_1_Fast_Generate_Preview = "veo-3.1-fast-generate-preview";
    public const string Veo_3_1_Lite_Generate_Preview = "veo-3.1-lite-generate-preview";
    public const string Veo_3_Generate = "veo-3.0-generate-001";
    public const string Veo_3_Fast = "veo-3.0-fast-generate-001";

    // ===== Lyria (Music) =====
    public const string Lyria_3_Clip_Preview = "lyria-3-clip-preview";
    public const string Lyria_3_Pro_Preview = "lyria-3-pro-preview";

    public static decimal? CalculateCost(string modelName, UsageMetadata usage)
    {
        switch (modelName.Trim().ToLowerInvariant())
        {
            case Gemini_3_6_Flash:
                return CalculateCost(usage, 1.50m, 0.15m, 7.50m);
            case Gemini_3_5_Flash:
                return CalculateCost(usage, 1.50m, 0.15m, 9.00m);
            case Gemini_3_5_Flash_Lite:
                return CalculateCost(usage, 0.30m, 0.03m, 2.50m);
            case Gemini_3_1_Flash_Lite:
            case Gemini_3_1_Flash_Lite_Preview:
                return CalculateCost(usage, 0.25m, 0.025m, 1.50m);
            case Gemini_3_1_Pro_Preview:
            case Gemini_3_1_Pro_Preview_CustomTools:
            case Gemini_3_Pro_Preview:
                return usage.PromptTokenCount > 200_000
                    ? CalculateCost(usage, 4.00m, 0.40m, 18.00m)
                    : CalculateCost(usage, 2.00m, 0.20m, 12.00m);
            case Gemini_3_Flash_Preview:
                return CalculateCost(usage, 0.50m, 0.05m, 3.00m);
            case Gemini_2_5_Pro:
                return usage.PromptTokenCount > 200_000
                    ? CalculateCost(usage, 2.50m, 0.25m, 15.00m)
                    : CalculateCost(usage, 1.25m, 0.125m, 10.00m);
            case Gemini_2_5_Flash:
                return CalculateCost(usage, 0.30m, 0.03m, 2.50m);
            case Gemini_2_5_Flash_Lite:
            case Gemini_2_5_Flash_Lite_Preview_09_2025:
                return CalculateCost(usage, 0.10m, 0.01m, 0.40m);
            case Gemini_3_1_Flash_Live_Preview:
                return CalculateCost(usage, 0.75m, 0m, 4.50m);
            case Gemini_3_1_Flash_Image:
            case Gemini_3_1_Flash_Image_Preview:
                return CalculateCost(usage, 0.50m, 0.50m, 3.00m);
            case Gemini_3_1_Flash_Lite_Image:
                return CalculateCost(usage, 0.25m, 0.25m, 1.50m);
            case Gemini_3_Pro_Image:
            case Gemini_3_Pro_Image_Preview:
                return CalculateCost(usage, 2.00m, 0.20m, 12.00m);
            case Gemini_2_5_Flash_Image:
                return CalculateCost(usage, 0.30m, 0.03m, 0m);
            case Gemini_Omni_Flash_Preview:
                return CalculateCost(usage, 1.50m, 0m, 9.00m);
            case Gemini_Robotics_ER_2_Preview:
                return CalculateCost(usage, 2.00m, 0.20m, 10.00m);
            default: return null;
        }
    }
    public static decimal CalculateCost(UsageMetadata usage, decimal inputPrice, decimal cachedInputPrice, decimal outputPrice)
    {
        return (
            (usage.GetInputTokenCount() * inputPrice) +
            (usage.CachedContentTokenCount * cachedInputPrice) +
            (usage.GetOutputTokenCount() * outputPrice)
        ) / 1_000_000m;
    }
}
