﻿using System;
using System.Text;

namespace JumpList.Automatic;

public class DestListHeader
{
    public DestListHeader(byte[] rawBytes)
    {
        Version = BitConverter.ToInt32(rawBytes, 0);
        NumberOfEntries = BitConverter.ToInt32(rawBytes, 4);
        NumberOfPinnedEntries = BitConverter.ToInt32(rawBytes, 8);
        UnknownCounter = BitConverter.ToSingle(rawBytes, 12);
        LastEntryNumber = BitConverter.ToInt32(rawBytes, 16);
        Unknown1 = BitConverter.ToInt32(rawBytes, 20);
        LastRevisionNumber = BitConverter.ToInt32(rawBytes, 24);
        Unknown2 = BitConverter.ToInt32(rawBytes, 28);
    }

    public int Version { get; }
    public int NumberOfEntries { get; internal set; }
    public int NumberOfPinnedEntries { get; }
    public float UnknownCounter { get; }
    public int LastEntryNumber { get; }
    public int Unknown1 { get; }
    public int LastRevisionNumber { get; }
    public int Unknown2 { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Version: {Version}");
        sb.AppendLine($"NumberOfEntries: {NumberOfEntries}");
        sb.AppendLine($"NumberOfPinnedEntries: {NumberOfPinnedEntries}");
        sb.AppendLine($"LastEntryNumber: {LastEntryNumber}");
        sb.AppendLine($"LastRevisionNumber: {LastRevisionNumber}");
        sb.AppendLine($"Unknown0: {UnknownCounter}");
        sb.AppendLine($"AccessCount: {Unknown1}");
        sb.AppendLine($"Unknown2: {Unknown2}");

        return sb.ToString();
    }

    public byte[] ToBytes()
    {
        var bytes = new byte[32];
        BitConverter.TryWriteBytes(new Span<byte>(bytes, 0, 4), Version);
        BitConverter.TryWriteBytes(new Span<byte>(bytes, 4, 4), NumberOfEntries);
        BitConverter.TryWriteBytes(new Span<byte>(bytes, 8, 4), NumberOfPinnedEntries);
        BitConverter.TryWriteBytes(new Span<byte>(bytes, 12, 4), UnknownCounter);
        BitConverter.TryWriteBytes(new Span<byte>(bytes, 16, 4), LastEntryNumber);
        BitConverter.TryWriteBytes(new Span<byte>(bytes, 20, 4), Unknown1);
        BitConverter.TryWriteBytes(new Span<byte>(bytes, 24, 4), LastRevisionNumber);
        BitConverter.TryWriteBytes(new Span<byte>(bytes, 28, 4), Unknown2);
        return bytes;
    }
}