using Newtonsoft.Json;

namespace HigLabo.Core
{
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
        public Dictionary<string, InputValidateResult> ResultList { get; } = new();

        public void Add(string key, string message)
        {
            ResultList.Add(key, new InputValidateResult(false, message));
        }
        public void Add(string key, InputValidateResult result)
        {
            ResultList.Add(key, result);
        }
        public void Add(bool condition, string key, string message)
        {
            if (condition)
            {
                ResultList.Add(key, new InputValidateResult(false, message));
            }
        }

        public List<InputError> GetInputErrorList()
        {
            return GetInputErrorList("");
        }
        public List<InputError> GetInputErrorList(string errorPopupMessage)
        {
            var l = new List<InputError>();
            foreach (var kv in this.ResultList)
            {
                if (kv.Value.Valid == false)
                {
                    var error = l.Find(el => el.Key == kv.Key);
                    if (error == null)
                    {
                        error = new InputError();
                        error.Key = kv.Key; 
                        error.Message = kv.Value.Message;
                        l.Add(error);
                    }
                    else
                    {
                        error.Message = Environment.NewLine + kv.Value.Message;
                    }
                }
            }
            if (l.Count > 0 && errorPopupMessage.HasValue())
            {
                l.Add(InputError.CreateErrorPopup(errorPopupMessage));
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
            this.ResultList.Add("ErrorPopup", new InputValidateResult(false, message));
        }
    }
}
