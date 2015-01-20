using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HigLabo.Web.Module
{
    public class DosAttackProtectModule : IHttpModule
    {
        public event EventHandler<DosAttackProtectValidateEventArgs> DosAttackDetected;

        public DosAttackProtectMode Mode { get; set; }
        public List<IDosAttackProtectCondition> Conditions { get; private set; }

        public DosAttackProtectModule()
        {
            this.Mode = DosAttackProtectMode.None;
            this.Conditions = new List<IDosAttackProtectCondition>();
        }
        public void Init(HttpApplication context)
        {
            var cx = context;

            cx.AuthenticateRequest += (o, e) => this.Validate();
        }

        private void Validate()
        {
            var req = HttpContext.Current.Request;
            Boolean hasPermission = this.Mode == DosAttackProtectMode.None;

            foreach (var condition in this.Conditions)
            {
                if (this.Mode == DosAttackProtectMode.None)
                {
                    //拒否設定が１こ以上ある場合は拒否が優先
                    if (condition.Validate(req) == false)
                    {
                        hasPermission = false;
                        break;
                    }
                }
                else if (this.Mode == DosAttackProtectMode.ProtectAll)
                {
                    var result = condition.Validate(req);
                    if (result == true)
                    {
                        hasPermission = true;
                    }
                    else if (result == false)
                    {
                        //拒否設定が１こ以上ある場合は拒否が優先
                        hasPermission = false;
                        break;
                    }
                }
            }
            if (hasPermission == false)
            {
                this.OnDosAttackDetected(new DosAttackProtectValidateEventArgs());
            }
        }
        protected void OnDosAttackDetected(DosAttackProtectValidateEventArgs e)
        {
            var eh = this.DosAttackDetected;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        public void Dispose()
        {
        }

    }
}