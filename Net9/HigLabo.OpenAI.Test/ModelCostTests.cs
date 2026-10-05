using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HigLabo.OpenAI.Test;

[TestClass]
public class ModelCostTests
{
    [TestMethod]
    public void CacheReadsAndWritesAreNotCountedAsOrdinaryInput()
    {
        var usage = new ResponseUsageResult
        {
            Input_Tokens = 20000, Output_Tokens = 1000,
            Input_Tokens_Details = new() { Cached_Tokens = 12000, Cache_Write_Tokens = 3000 },
        };
        Assert.AreEqual(0.0287m, ModelNames.CalculateCost(ModelNames.Gpt_6_1_Sol, usage));
        Assert.AreEqual(0.0287m, ModelNames.CalculateCost(usage, 2m, 0.1m, 10m, 2.5m));
        // The existing explicit-price overload retains its historical cache-write rate.
        Assert.AreEqual(0.0272m, ModelNames.CalculateCost(usage, 2m, 0.1m, 10m));
    }

    [TestMethod]
    public void LongContextThresholdUsesTotalInputIncludingCachedTokens()
    {
        var usage = new ResponseUsageResult
        {
            Input_Tokens = 272000, Output_Tokens = 1000,
            Input_Tokens_Details = new() { Cached_Tokens = 270000, Cache_Write_Tokens = 1000 },
        };
        Assert.AreEqual(0.0415m, ModelNames.CalculateCost(ModelNames.Gpt_6_1_Sol, usage));
        usage.Input_Tokens++;
        Assert.AreEqual(0.078004m, ModelNames.CalculateCost(ModelNames.Gpt_6_1_Sol, usage));
    }

    [TestMethod]
    public void ChatCompletionsUseCachedInputDiscount()
    {
        var usage = new ChatCompletionUsageResult
        {
            Prompt_Tokens = 1000, Completion_Tokens = 100,
            Prompt_Tokens_Details = new() { Cached_Tokens = 800 },
        };
        Assert.AreEqual(0.00148m, ModelNames.CalculateCost(ModelNames.Gpt_6_1_Sol, usage));
        usage.Prompt_Tokens_Details = null!;
        Assert.AreEqual(0.003m, ModelNames.CalculateCost(ModelNames.Gpt_6_1_Sol, usage));
    }

    [TestMethod]
    public void NewTextModelsAndPromotionalPriceAreRecognized()
    {
        var usage = new ResponseUsageResult { Input_Tokens = 1000, Output_Tokens = 1000 };
        Assert.AreEqual(0.012m, ModelNames.CalculateCost(" GPT-6-SOL ", usage));
        Assert.AreEqual(0.0006m, ModelNames.CalculateCost(ModelNames.Gpt_6_Luna, usage));
        Assert.AreEqual(0.024m, ModelNames.CalculateCost(ModelNames.Gpt_5_6_Sol, usage));
        Assert.AreEqual(0.024m, ModelNames.CalculateCost(ModelNames.Gpt_5_6, usage));
        Assert.IsNull(ModelNames.CalculateCost("unknown", usage));
        Assert.IsNull(ModelNames.CalculateCost(ModelNames.Gpt_Live_1, usage));
        Assert.IsNull(ModelNames.CalculateCost(ModelNames.Gpt_Image_2_5_Flare, usage));
    }

    [TestMethod]
    public void OlderModelsAndMissingUsageDetailsRemainSupported()
    {
        var usage = new ResponseUsageResult { Input_Tokens = 1000, Output_Tokens = 100, Input_Tokens_Details = null! };
        Assert.AreEqual(0.002m, ModelNames.CalculateCost(ModelNames.Gpt_4_1, new ResponseUsageResult { Input_Tokens = 1000 }));
        Assert.AreEqual(0.0028m, ModelNames.CalculateCost(ModelNames.Gpt_4_1, usage));
    }
}
