using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyBetter.Core;

namespace HigLabo.Core
{
    public class ValidationFailureException : Exception
    {
        public override string Message
        {
            get
            {
                return this.ValidationResultList.ToString();
            }
        }
        public ValidationResultList ValidationResultList { get; private set; } = new ValidationResultList();

        public ValidationFailureException(ValidationResult result)
        {
            if (result != null)
            {
                this.ValidationResultList.Add(result);
            }
        }
        public ValidationFailureException(IEnumerable<ValidationResult> resultList)
        {
            foreach (var item in resultList.Where(el => el != null))
            {
                this.ValidationResultList.Add(item);
            }
        }
    }
}
