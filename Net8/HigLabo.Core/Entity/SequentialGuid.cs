﻿//-----------------------------------------------------------------------
// <copyright file="SequentialGuid.cs" company="Jeremy H. Todd">
//     Copyright © Jeremy H. Todd 2011
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Security.Cryptography;

namespace HigLabo.Core;

/// <summary>
/// PrimaryKeyがクラスタ化インデックスのGuidの場合にSystem.Guidクラスをそのまま使用するとランダムに値が生成されてレコードが挿入される結果
/// データベースのレコードがHD上で断片化しパフォーマンスが低下する問題があります。
/// このクラスでGuidを生成することでシーケンシャルにGuidを生成でき断片化を抑制できます。
/// </summary>
public static class SequentialGuid
{
    private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();
    public static SequentialGuidType Default = SequentialGuidType.AtEnd;

    public static Guid NewGuid()
    {
        return NewGuid(Default);
    }
    public static Guid NewGuid(SequentialGuidDatabase database)
    {
        return NewGuid(database.GetSequentialGuidType());
    }
    public static Guid NewGuid(SequentialGuidType guidType)
    {
        byte[] randomBytes = new byte[10];
        _rng.GetBytes(randomBytes);

        long timestamp = DateTime.Now.Ticks / 10000L;
        byte[] timestampBytes = BitConverter.GetBytes(timestamp);

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(timestampBytes);
        }
        byte[] guidBytes = new byte[16];
        switch (guidType)
        {

            case SequentialGuidType.String:
            case SequentialGuidType.Binary:
                Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
                Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10);
                if (guidType == SequentialGuidType.String && BitConverter.IsLittleEndian)
                {
                    Array.Reverse(guidBytes, 0, 4);
                    Array.Reverse(guidBytes, 4, 2);
                }
                break;
            case SequentialGuidType.AtEnd:
                Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
                Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);
                break;
        }
        return new Guid(guidBytes);
    }
}
