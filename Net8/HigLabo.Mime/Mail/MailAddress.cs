﻿using System;
using System.Collections.Generic;
using System.Linq;
#if !NETFX_CORE
using System.Security.Cryptography.X509Certificates;
#endif
using System.Text;

namespace HigLabo.Mime;

public class MailAddress
{
    private String _RawValue = "";
    private String _Value = "";
    private String _DisplayName = "";
    private String _UserName = "";
    private String _DomainName = "";

    public Boolean AsciiCharOnly { get; set; }
    public String RawValue
    {
        get { return this._RawValue; }
        private set { this._RawValue = value; }
    }
    public String Value
    {
        get { return this._Value; }
        private set { this._Value = value; }
    }
    public String DisplayName
    {
        get { return this._DisplayName; }
        private set { this._DisplayName = value; }
    }
    public String UserName
    {
        get { return this._UserName; }
        private set { this._UserName = value; }
    }
    public String DomainName
    {
        get { return this._DomainName; }
        private set { this._DomainName = value; }
    }
    public Boolean ValidFormat { get; set; }
    public X509Certificate2? SigningCertificate { get; set; }
    public X509Certificate2? EncryptionCertificate { get; set; }

    public MailAddress(String value)
    {
        SetProperty(this, value);
    }
    public static MailAddress? TryCreate(String value)
    {
        if (String.IsNullOrEmpty(value) == true) { return null; }
        return new MailAddress(value);
    }
    private static void SetProperty(MailAddress mailAddress, String value)
    {
        MailAddress m = mailAddress;
        var trimValue = value.Trim();
        Int32 displayNameEndIndex = 0;
        Int32 valueIndex = -1;
        Int32 valueEndIndex = -1;
        Int32 atmarkIndex = -1;

        m.AsciiCharOnly = true;
        for (int i = 0; i < trimValue.Length; i++)
        {
            if ((Byte)trimValue[i] >= 128)
            {
                m.AsciiCharOnly = false;
            }
            if (trimValue[i] == ' ')
            {
                displayNameEndIndex = i;
            }
            if (trimValue[i] == '<')
            {
                valueIndex = i + 1;
            }
            if (trimValue[i] == '@')
            {
                atmarkIndex = i;
            }
            if (atmarkIndex > -1 &&
                trimValue[i] == '>')
            {
                valueEndIndex = i;
                break;
            }
        }
        if (atmarkIndex == -1)
        {
            m.ValidFormat = false;
            m.RawValue = value;
            return;
        }
        m.ValidFormat = true;
        if (valueEndIndex == -1) { valueEndIndex = trimValue.Length - 1; }
        if (valueIndex > -1)
        {
            //"Bill Gates" <bill@microsoft.com>
            //Bill <bill@microsoft.com>
            //<bill@microsoft.com>
            m.DisplayName = trimValue.Substring(0, displayNameEndIndex).Trim();
            if (m.DisplayName.Length > 1 &&
                m.DisplayName[0] == '"' &&
                m.DisplayName[m.DisplayName.Length - 1] == '"')
            {
                m.DisplayName = m.DisplayName.Substring(1, m.DisplayName.Length - 2);
            }
            m.Value = trimValue.Substring(valueIndex, valueEndIndex - valueIndex);
            m.UserName = trimValue.Substring(valueIndex, atmarkIndex - valueIndex);
            m.DomainName = trimValue.Substring(atmarkIndex + 1, valueEndIndex - atmarkIndex - 1);
        }
        else
        {
            //bill@microsoft.com
            valueIndex = 0;
            m.Value = value;
            m.UserName = trimValue.Substring(valueIndex, atmarkIndex - valueIndex);
            m.DomainName = trimValue.Substring(atmarkIndex + 1, valueEndIndex - atmarkIndex);
        }
        m.RawValue = value;
    }

    public static List<MailAddress> CreateMailAddressList(String mailAddressListText)
    {
        return CreateMailAddressList(mailAddressListText, ',', ';');
    }
    public static List<MailAddress> CreateMailAddressList(String mailAddressListText, params Char[] separators)
    {
        List<MailAddress> l = new List<MailAddress>();
        Boolean isSeparator = false;
        Int32 index = 0;

        for (int i = 0; i < mailAddressListText.Length; i++)
        {
            isSeparator = false;
            if (i == mailAddressListText.Length - 1)
            {
                String s = mailAddressListText.Substring(index, mailAddressListText.Length - index);
                var m = MailAddress.TryCreate(s.Trim());
                if (m != null)
                {
                    l.Add(m);
                }
                break;
            }
            else
            {
                for (int cIndex = 0; cIndex < separators.Length; cIndex++)
                {
                    if (mailAddressListText[i] == separators[cIndex])
                    {
                        isSeparator = true;
                        break;
                    }
                }
            }
            if (isSeparator == true)
            {
                String s = mailAddressListText.Substring(index, i - index);
                var m = MailAddress.TryCreate(s.Trim());
                if (m != null)
                {
                    l.Add(m);
                }
                index = i + 1;
            }
        }
        return l;
    }

    public override string ToString()
    {
        return this.RawValue;
    }
}
