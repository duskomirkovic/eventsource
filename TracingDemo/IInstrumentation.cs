public interface IInstrumentation
{
    void GetSomeDataStart();
    void GetSomeDataStop();
    void GetSomeMoreDataStart();
    void GetSomeMoreDataStop();
    void IndexGetStart();
    void IndexGetStop();
    void SomeIntermediateState(string v1, string v2, string v3);
}