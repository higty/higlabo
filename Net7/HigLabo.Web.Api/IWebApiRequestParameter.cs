using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
	public interface IWebApiRequestParameter<T>
		where T : class, IValidateResult
	{
		public T Validate();
	}
}
