using System;
using System.Collections.Generic;

namespace HigLabo.Net
{
    public partial class OAuth1Client
    {
        /// <summary>
        /// Provides a predefined set of algorithms that are supported officially by the protocol
        /// </summary>
        public enum SignatureTypes
        {
            /// <summary>
            /// 
            /// </summary>
            HMACSHA1,
            /// <summary>
            /// 
            /// </summary>
            PLAINTEXT,
            /// <summary>
            /// 
            /// </summary>
            RSASHA1,
        }
        /// <summary>
        /// Provides an internal structure to sort the query parameter
        /// </summary>
        protected class QueryParameter
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <param name="value"></param>
            public QueryParameter(String name, String value)
            {
                this.Name = name;
                this.Value = value;
            }

            /// <summary>
            /// 
            /// </summary>
            public string Name { get; private set; }
            /// <summary>
            /// 
            /// </summary>
            public string Value { get; private set; }
        }
        /// <summary>
        /// Comparer class used to perform the sorting of the query parameters
        /// </summary>
        protected class QueryParameterComparer : IComparer<QueryParameter>
        {
            #region IComparer<QueryParameter> Members

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(QueryParameter x, QueryParameter y)
            {
                if (x.Name == y.Name)
                {
                    return String.Compare(x.Value, y.Value);
                }
                return String.Compare(x.Name, y.Name);
            }

            #endregion
        }
    }
}