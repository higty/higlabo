using Newtonsoft.Json;

namespace HigLabo.Core;

public class InputError
{
    public string Key { get; set; } = "";
    public string Message { get; set; } = "";

    public InputError() { }
    public InputError(string key, string message)
    {
        this.Key = key;
        this.Message = message;
    }

    public static InputError CreateErrorPopup(string message)
    {
        var error = new InputError();
        error.Key = "ErrorPopup";
        error.Message = message;
        return error;
    }

    public override string ToString()
    {
        return $"{this.Key} {this.Message}";
    }
}

public class InputErrorData
{
    public List<InputError> ResultList { get; } = new();

    public void Add(string key, string message)
    {
        ResultList.Add(new InputError(key, message));
    }
    public void Add(string key, InputValidateResult result)
    {
        if (result.Valid == false)
        {
            ResultList.Add(new InputError(key, result.Message));
        }
    }
    public void Add(bool condition, string key, string message)
    {
        if (condition)
        {
            ResultList.Add(new InputError(key, message));
        }
    }

    public List<InputError> GetInputErrorList()
    {
        return GetInputErrorList("");
    }
    public List<InputError> GetInputErrorList(string errorPopupMessage)
    {
        var l = new List<InputError>();
        foreach (var item in this.ResultList)
        {
            var error = l.Find(x => x.Key == item.Key);
            if (error == null)
            {
                error = new InputError();
                error.Key = item.Key;
                error.Message = item.Message;
                l.Add(error);
            }
            else
            {
                error.Message = Environment.NewLine + item.Message;
            }
        }
        if (l.Count > 0 && errorPopupMessage.HasValue())
        {
            if (l.Exists(x => x.Key == "ErrorPopup") == false)
            {
                l.Add(InputError.CreateErrorPopup(errorPopupMessage));
            }
        }
        return l;
    }
    public static InputError CreateError(string message)
    {
        var error = new InputError();
        error.Key = "Error";
        error.Message = message;
        return error;
    }
    public void AddErrorPopup(string message)
    {
        this.ResultList.Add(new InputError("ErrorPopup", message));
    }
}
