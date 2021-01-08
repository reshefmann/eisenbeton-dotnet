// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace eisenbeton.wire.request
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct EisenRequest : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static EisenRequest GetRootAsEisenRequest(ByteBuffer _bb) { return GetRootAsEisenRequest(_bb, new EisenRequest()); }
  public static EisenRequest GetRootAsEisenRequest(ByteBuffer _bb, EisenRequest obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public EisenRequest __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Uri { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetUriBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetUriBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetUriArray() { return __p.__vector_as_array<byte>(4); }
  public string Path { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPathBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetPathBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetPathArray() { return __p.__vector_as_array<byte>(6); }
  public string Method { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetMethodBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetMethodBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetMethodArray() { return __p.__vector_as_array<byte>(8); }
  public string ContentType { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetContentTypeBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetContentTypeBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetContentTypeArray() { return __p.__vector_as_array<byte>(10); }
  public byte Content(int j) { int o = __p.__offset(12); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int ContentLength { get { int o = __p.__offset(12); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetContentBytes() { return __p.__vector_as_span<byte>(12, 1); }
#else
  public ArraySegment<byte>? GetContentBytes() { return __p.__vector_as_arraysegment(12); }
#endif
  public byte[] GetContentArray() { return __p.__vector_as_array<byte>(12); }

  public static Offset<eisenbeton.wire.request.EisenRequest> CreateEisenRequest(FlatBufferBuilder builder,
      StringOffset uriOffset = default(StringOffset),
      StringOffset pathOffset = default(StringOffset),
      StringOffset methodOffset = default(StringOffset),
      StringOffset content_typeOffset = default(StringOffset),
      VectorOffset contentOffset = default(VectorOffset)) {
    builder.StartTable(5);
    EisenRequest.AddContent(builder, contentOffset);
    EisenRequest.AddContentType(builder, content_typeOffset);
    EisenRequest.AddMethod(builder, methodOffset);
    EisenRequest.AddPath(builder, pathOffset);
    EisenRequest.AddUri(builder, uriOffset);
    return EisenRequest.EndEisenRequest(builder);
  }

  public static void StartEisenRequest(FlatBufferBuilder builder) { builder.StartTable(5); }
  public static void AddUri(FlatBufferBuilder builder, StringOffset uriOffset) { builder.AddOffset(0, uriOffset.Value, 0); }
  public static void AddPath(FlatBufferBuilder builder, StringOffset pathOffset) { builder.AddOffset(1, pathOffset.Value, 0); }
  public static void AddMethod(FlatBufferBuilder builder, StringOffset methodOffset) { builder.AddOffset(2, methodOffset.Value, 0); }
  public static void AddContentType(FlatBufferBuilder builder, StringOffset contentTypeOffset) { builder.AddOffset(3, contentTypeOffset.Value, 0); }
  public static void AddContent(FlatBufferBuilder builder, VectorOffset contentOffset) { builder.AddOffset(4, contentOffset.Value, 0); }
  public static VectorOffset CreateContentVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateContentVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartContentVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static Offset<eisenbeton.wire.request.EisenRequest> EndEisenRequest(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<eisenbeton.wire.request.EisenRequest>(o);
  }
  public static void FinishEisenRequestBuffer(FlatBufferBuilder builder, Offset<eisenbeton.wire.request.EisenRequest> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedEisenRequestBuffer(FlatBufferBuilder builder, Offset<eisenbeton.wire.request.EisenRequest> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
