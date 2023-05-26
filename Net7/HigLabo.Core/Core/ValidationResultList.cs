using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ValidationResultList : List<ValidationResult>
    {
        public static readonly ValidationResultList Empty = new ValidationResultList();

        public ValidationResultList() { }
        public ValidationResultList(ValidationResult result)
        {
            this.Add(result);
        }

        public void AddResult(String name, String message)
        {
            this.Add(new ValidationResult(name, message));
        }
        public void Add(String name, String message)
        {
            this.Add(new ValidationResult(name, message));
        }
        public void AddIfNotNull(ValidationResult result)
        {
            if (result != null)
            {
                this.Add(result);
            }
        }
        public Boolean Exists(String name)
        {
            return this.Exists(el => el.Name == name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this[i].Message).AppendLine();
            }
            return sb.ToString();
        }
    }
}
